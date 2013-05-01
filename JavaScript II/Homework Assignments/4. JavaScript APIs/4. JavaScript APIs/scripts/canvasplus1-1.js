/* CanvasPlus v1.1
 * Copyright (c) 2010 Julian Rosenblum
 * Licensed under the MIT license: http://www.opensource.org/licenses/mit-license.php
 */

var canvasPlus = function (id) {
    var canvas = document.getElementById(id),
    ctx,
    frames = [],
    frame,
    distance = function (x1, y1, x2, y2) {
        return Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
    };
    if (!canvas.getContext) {
        if (!canvas.firstChild) {
            canvas.innerHTML = 'Your browser does not support Canvas';
        }
    }
    try {
        ctx = canvas.getContext('2d');
        // Canvas functions
        ctx.clear = function () {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
        };
        ctx.applyStyleObject = function (obj, save) {
            var i;
            if (save) {
                ctx.save();
            }
            for (i in obj) {
                if (obj.hasOwnProperty(i)) {
                    ctx[i] = obj[i];
                }
            }
        };
        ctx.rotateFromPoint = function (x, y, r) {
            ctx.translate(x, y);
            ctx.rotate(r);
            ctx.translate(-x, -y);
        };
        ctx.rotateFromCenter = function (r) {
            ctx.rotateFromPoint(canvas.width / 2, canvas.height / 2, r);
        };
        ctx.saveFrame = function () {
            frame = document.createElement('canvas');
            frame.width = canvas.width;
            frame.height = canvas.height;
            frame.getContext('2d').drawImage(canvas, 0, 0);
            frames[frames.length] = frame;
        };
        ctx.restoreFrameOverlay = function () {
            ctx.drawImage(frames[frames.length - 1], 0, 0);
            frames.pop();
        };
        ctx.restoreFrame = function () {
            ctx.clear();
            ctx.restoreFrameOverlay();
        };
        ctx.mouseX = function (e) {
            return e.offsetX || e.pageX - canvas.offsetLeft;
        };
        ctx.mouseY = function (e) {
            return e.offsetY || e.pageY - canvas.offsetTop;
        };
        // Shape functions
        ctx.drawRect = function (fill, x, y, w, h, r) {
            ctx.save();
            if (r) {
                ctx.rotateFromPoint(x + (w / 2), y + (h / 2), r);
            }
            ctx[fill + 'Rect'](x, y, w, h);
            ctx.restore();
        };
        ctx.drawCircle = function (fill, x, y, rad) {
            ctx.save();
            ctx.beginPath();
            ctx.arc(x, y, rad, 0, Math.PI * 2, false);
            ctx[fill]();
            ctx.restore();
        };
        ctx.drawEllipse = function (fill, x, y, rad1, rad2, r) {
            ctx.save();
            if (r) {
                ctx.rotateFromPoint(x, y, r);
            }
            ctx.save();
            ctx.scale(rad1, rad2);
            ctx.beginPath();
            ctx.arc(x / rad1, y / rad2, 1, 0, Math.PI * 2, false);
            ctx.restore();
            ctx[fill]();
            ctx.restore();
        };
        ctx.drawEllipseFromFoci = function (fill, f1x, f1y, f2x, f2y, dist) {
            var center = [(f1x + f2x) / 2, (f1y + f2y) / 2],
            a = dist / 2,
            c = distance(f1x, f1y, center[0], center[1]);
            ctx.drawEllipse(fill, center[0], -center[1], a, Math.sqrt(Math.pow(a, 2) - Math.pow(c, 2)), Math.atan2(f2x - f1x, f2y - f1y) + Math.PI / 2);
        };
        ctx.drawPolygon = function (fill/*, x1, y1, x2, y2, etc */) {
            var i;
            ctx.beginPath();
            ctx.moveTo(arguments[1], arguments[2]);
            for (i = 3; i < arguments.length; i += 2) {
                ctx.lineTo(arguments[i], arguments[i + 1]);
            }
            ctx.closePath();
            ctx[fill]();
        };
        ctx.drawEquilateral = function (fill, x, y, b, r) {
            ctx.save();
            if (r) {
                ctx.rotateFromPoint(x, y + (b / 4 * Math.sqrt(3)), r);
            }
            ctx.drawPolygon(fill, x, y, x - (b / 2), y + (b / 2 * Math.sqrt(3)), x + (b / 2), y + (b / 2 * Math.sqrt(3)));
            ctx.restore();
        };
        ctx.drawIsosceles = function (fill, x, y, b, h, r) {
            ctx.save();
            if (r) {
                ctx.rotateFromPoint(x, y + (h / 2), r);
            }
            ctx.drawPolygon(fill, x, y, x - (b / 2), y + h, x + (b / 2), y + h);
            ctx.restore();
        };
        ctx.drawScalene = function (fill, x, y, x1, y1, x2, y2, r) {
            ctx.save();
            if (r) {
                ctx.rotateFromPoint((x + x1 + x2) / 3, (y + y1 + y2) / 3, r);
            }
            ctx.drawPolygon(fill, x, y, x1, y1, x2, y2);
            ctx.restore();
        };
        ctx.drawLine = function (x, y, x1, y1) {
            ctx.beginPath();
            ctx.moveTo(x, y);
            ctx.lineTo(x1, y1);
            ctx.stroke();
        };
        // Image functions
        ctx.drawImageAndRotate = function (/* 4, 6, or 10 arguments */) {
            ctx.save();
            if (arguments.length === 4) {
                ctx.rotateFromPoint(arguments[1] + arguments[0].width / 2, arguments[2] + arguments[0].height / 2, arguments[3]);
                ctx.drawImage(arguments[0], arguments[1], arguments[2]);
            }
            else if (arguments.length === 6) {
                ctx.rotateFromPoint(arguments[1] + arguments[3] / 2, arguments[2] + arguments[4] / 2, arguments[5]);
                ctx.drawImage(arguments[0], arguments[1], arguments[2], arguments[3], arguments[4]);
            }
            else if (arguments.length === 10) {
                ctx.rotateFromPoint(arguments[5] + arguments[7] / 2, arguments[6] + arguments[8] / 2, arguments[9]);
                ctx.drawImage(arguments[0], arguments[1], arguments[2], arguments[3], arguments[4], arguments[5], arguments[6], arguments[7], arguments[8]);
            }
            else {
                throw 'Invalid number of arguments.';
            }
            ctx.restore();
        };
        return ctx;
    } catch (e) {
        return false;
    }
};