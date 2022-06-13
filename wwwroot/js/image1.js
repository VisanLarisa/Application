// JavaScript source code
function init1() {
    canvas = document.getElementById('MyCanvas1');
    ctx = canvas.getContext('2d');
    centerX = 0;
    centerY = 0;
    radius = 50;
    // translate context
    ctx.translate(canvas.width / 2, canvas.height / 2);
    // scale context horizontally
    ctx.scale(1, 1);
    // draw circle and stretch it into an ellipse
    ctx.beginPath();
    ctx.arc(centerX, centerY, radius, 0,  Math.PI, false);
    ctx.arc(centerX, centerY, radius, 0,  3*Math.PI, false);
    ctx.lineWidth = 5;
    ctx.strokeStyle = 'grey';
    ctx.stroke();

    radius = 100;
    ctx.beginPath();
    ctx.arc(centerX, centerY, radius, 0, 3 * Math.PI, false);
    ctx.lineWidth = 3;
    ctx.strokeStyle = 'grey';
    ctx.stroke();

    centerX = 80;
    centerY = 0;
    radius = 80;
    ctx.arc(centerX, centerY, radius, 0,  2*Math.PI, false);
    ctx.lineWidth = 3;
    ctx.strokeStyle = 'grey';
    ctx.stroke();
}
