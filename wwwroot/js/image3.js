function init3() {
    context = document.getElementById('MyCanvas3').getContext('2d');
    image = new Image();
    image.src = "Images\fotTatoo.jpg";
    image.onload=function () {
    // Top left
    //context.translate(50, 50);
    var image=new Image();
    context.drawImage(image, 0, 0,image.width, image.height, 0, 0,image.width, image.height);
   
}
}