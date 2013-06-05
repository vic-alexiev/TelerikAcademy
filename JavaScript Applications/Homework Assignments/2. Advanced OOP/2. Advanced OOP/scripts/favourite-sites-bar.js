var Site = Class.create({
    initialize: function (title, url) {
        this.title = title;
        this.url = url;
    }
});

var Folder = Class.create({
    initialize: function (title, sites) {
        this.title = title;
        this.sites = sites;
    },

    addSite: function (site) {
        this.sites.push(site);
    },

    loadSites: function () {
        var sitesHolder = document.createDocumentFragment();

        for (var i = 0; i < this.sites.length; i++) {

            var siteItem = document.createElement("li");
            var link = document.createElement("a");
            link.innerHTML = this.sites[i].title;
            link.title = this.sites[i].title;
            link.target = "_blank";
            link.href = this.sites[i].url;
            siteItem.appendChild(link);
            sitesHolder.appendChild(siteItem);
        }

        return sitesHolder;
    }
});

var FavouriteSitesBar = Class.create(Folder, {
    initialize: function ($super, containerId, sites, folders) {
        $super("", sites);
        this.containerId = containerId;
        this.folders = folders;
    },

    load: function () {
        var container = document.getElementById(this.containerId);

        var sitesBar = document.createElement("ul");

        if (this.sites.length > 0) {
            var sitesHolder = this.loadSites();
            sitesBar.appendChild(sitesHolder);
        }

        for (var i = 0; i < this.folders.length; i++) {
            var folderItem = document.createElement("li");
            folderItem.innerHTML = this.folders[i].title;

            if (this.folders[i].sites.length > 0) {
                var sitesList = document.createElement("ul");
                var sitesHolder = this.folders[i].loadSites();
                sitesList.appendChild(sitesHolder);
                folderItem.appendChild(sitesList);
            }

            sitesBar.appendChild(folderItem);
        }

        container.appendChild(sitesBar);
    }
});