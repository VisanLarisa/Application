// window.onload=function(){

// }
window.onload = () => {
    var video = document.getElementById('video');

    var clearCanvas = document.getElementById('clearCanvas');
    var clearContext = clearCanvas.getContext('2d');


    var snapshotCanvas = document.getElementById('snapshotCanvas');
    var snapshotContext = snapshotCanvas.getContext('2d');

    var shootButton = document.getElementById('shoot');
    var gallery = document.getElementById('gallery');

    var width = 400;
    var height = 300;


    navigator.mediaDevices.getUserMedia({
        video: true,
        audio: false
    }).then((stream) => {
        video.srcObject = stream;
        video.play();
    });

    //aici bagam videoul in canvas
  //  $(video).on('') inlocuim cu:
    video.addEventListener('play',() => {
        render();        //take the picture and move it
    })

    computeClearFrame = () => {
        clearContext.drawImage(video, 0, 0, width, height);
    }

    render = () => {
        computeClearFrame();  
        //computeFilterFrame();      
        setTimeout(() => {//starts a new thread, for letting the mother function to end, so not overflowing the stack with call that calls that calls ...(full stack of the big mother function, which will never go further and finish)
            render();
        }, 0);
    }



    shootButton.addEventListener('click', () => {
        snapshotContext.drawImage(video, 0, 0, width, height);
        var data = snapshotCanvas.toDataURL('image/png');//converteste la imagine png
      
        //window.location.href=image;
        //var p=$('<img>') inlocuit cu:
        var p = document.createElement('img');
        p.setAttribute('src', data);
        // $(p).addClass('img-fluid') inlocuit cu:
        p.classList.add('img-fluid');
        p.classList.add('mb-4');//margin buttom 4

        var d = document.createElement('div');//creeaza un div
        d.classList.add('col-md-2');//2 coloane pt ecran mic

        d.appendChild(p);//atasez p intr-o coloana
       // gallery.appendChild(d);
    })

    download_img = function(el) {
        var image = snapshotCanvas.toDataURL('image/png');
        el.href = image;
      };
}