// // JavaScript source code
// function init2() {
//     context = document.getElementById('MyCanvas2').getContext('2d');
//     image = new Image();
//     image.src = "Images\forTatoo.jpg";
//     image.onload=function () {
//     // Top left
//     context.translate(50, 50);
//     context.drawImage(image, 0, 0,image.width, image.height, 0, 0,image.width/2, image.height/2);
//     // Bottom left
//     context.setTransform(1, 0, 0, 1, 0, 0); // Reset the transformation matrix
//     context.translate(50, 500);
//     context.scale(1, -1);
//         context.drawImage(image, 0, 0, image.width, image.height, 0, 0, image.width / 2, image.height / 2);
//     // Bottom right
//     context.setTransform(1, 0, 0, 1, 0, 0);
//     context.translate(500, 500);
//     context.scale(-1, -1);
//         context.drawImage(image, 0, 0, image.width, image.height, 0, 0, image.width / 2, image.height / 2);
//     // Top right
//     context.setTransform(1, 0, 0, 1, 0, 0);
//     context.translate(500, 50);
//     context.scale(-1, 1);
//         context.drawImage(image, 0, 0, image.width, image.height, 0, 0,image.width/2, image.height/2);
// }
// }

function init2() {
    context = document.getElementById("MyCanvas2").getContext('2d');
    context.fillStyle = "grey";
    context.shadowBlur = 20;
    context.shadowColor = "grey";
    performRotation();
}

function performRotation()
{
    context.setTransform(1, 0, 0, 1, 0, 0); // reset the matrix to the identity matrix
    xScale = Math.cos(3); //angle=45 degree
    ySkew = -Math.sin(0.7854);
    xSkew = Math.sin(0.7854);
    yScale = Math.cos(0.7854);
    xTrans = 200;
    yTrans = 200;

    context.transform(xScale, ySkew, xSkew, yScale, xTrans, yTrans);
    context.fillRect(-50, -50, 100, 100);
    // Top right
    context.setTransform(1, 0, 0, 1, 0, 0);
    context.translate(450, 50);
    context.scale(-1, 1);
    var image= new Image();
    //document.getElementById("image-container").appendChild(image);
    context.drawImage(image, 0, 0, 500, 500, 0, 0, 200, 200);
}
