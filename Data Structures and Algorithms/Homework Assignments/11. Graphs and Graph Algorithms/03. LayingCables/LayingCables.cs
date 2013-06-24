using NGenerics.Algorithms;
using NGenerics.DataStructures.General;
using System;
using System.Collections.Generic;

internal class LayingCables
{
    private static void AddEdge(Graph<int> graph, IList<Vertex<int>> vertices, int value1, int value2, int weight)
    {
        graph.AddEdge(vertices[value1 - 1], vertices[value2 - 1], weight);
    }

    private static void Main()
    {
        var graph = new Graph<int>(false);

        var vertexList = new List<Vertex<int>>();

        for (var i = 1; i < 10; i++)
        {
            vertexList.Add(graph.AddVertex(i));
        }

        /*            
             
         * a = 1
         * b = 2
         * c = 3
         * d = 4
         * e = 5
         * f = 6 
         * g = 7
         * h = 8
         * i = 9
              
        */

        // a
        AddEdge(graph, vertexList, 1, 2, 2);
        AddEdge(graph, vertexList, 1, 4, 1);

        // b
        AddEdge(graph, vertexList, 2, 3, 1);
        AddEdge(graph, vertexList, 2, 4, 5);
        AddEdge(graph, vertexList, 2, 5, 3);
        AddEdge(graph, vertexList, 2, 6, 2);

        // d
        AddEdge(graph, vertexList, 4, 5, 1);
        AddEdge(graph, vertexList, 4, 7, 2);
        AddEdge(graph, vertexList, 4, 8, 4);

        // e
        AddEdge(graph, vertexList, 5, 6, 4);
        AddEdge(graph, vertexList, 5, 8, 3);
        AddEdge(graph, vertexList, 5, 9, 4);

        // f
        AddEdge(graph, vertexList, 6, 9, 3);

        // h
        AddEdge(graph, vertexList, 8, 9, 5);

        //var resultGraph = GraphAlgorithms.KruskalsAlgorithm(graph);
        var resultGraph = GraphAlgorithms.PrimsAlgorithm(graph, vertexList[0]);

        Console.WriteLine("Result tree edges: " + resultGraph.Edges.Count);

        double totalCost = 0;

        foreach (var edge in resultGraph.Edges)
        {
            Console.WriteLine(
                "(From: {0}, To: {1}, Weight: {2})",
                edge.FromVertex.Data,
                edge.ToVertex.Data,
                edge.Weight);

            totalCost += edge.Weight;
        }

        Console.WriteLine("Total cost: " + totalCost);
    }
}
