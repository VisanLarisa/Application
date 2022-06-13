const cacheName = 'v1';
const cacheAssets = [
    'Images/audi.jpg',
    'Images/BMW.png',
    'meniu.html',
    'scripts/meniu.js',
    'style/meniu.css',
    'about.html',
    'clients.html',
    'contact.html',
    'dyeing.html',
    'Service.html',
    'services.html',
    'shop.html',
    'wheels.html',
    'videos/service_Trim.mp4',
    'style/about.css',
    'style/clients.css',
    'style/contact.css',
    'style/Service.css',
    'style/services.css',
    'sounds/bentley.mp3',
    'sounds/blue.mp3',
    'sounds/BMW.mp3',
    'sounds/bmw.mp3',
    'sounds/cadillac.mp3',
    'sounds/dacia.mp3',
    'sounds/fiat.mp3',
    'sounds/ford.mp3',
    'sounds/jaguar.mp3',
    'sounds/lamborghini.mp3',
    'sounds/lexus.mp3',
    'sounds/mercedes.mp3',
    'sounds/suzuki.mp3',
    'sounds/volvo.mp3',
    'scripts/contact.js',
    'scripts/image1.js',
    'scripts/image2.js',
    'scripts/image3.js',
    'scripts/video.js',
    'Images/bentley.jfif',
    'Images/cadillac.png',
    'Images/color1.jpg',
    'Images/color2.jpg',
    'Images/color3.jpg',
    'Images/color4.jpg',
    'Images/color5.jpg',
    'Images/color6.jpg',
    'Images/color7.jpg',
    'Images/color8.jpg',
    'Images/color9.jpg',
    'Images/color10.jpg',
    'Images/color11.jpg',
    'Images/color12.jpg',
    'Images/color13.jpg',
    'Images/color14.jpg',
    'Images/color15.jpg',
    'Images/color16.jpg',
    'Images/color17.jpg',
    'Images/color18.jpg',
    'Images/color19.jpg',
    'Images/color20.jpg',
    'Images/color21.jpg',
    'Images/color22.jpg',
    'Images/color23.jpg',
    'Images/color24.jpg',
    'Images/color25.jpg',
    'Images/color26.jpg',
    'Images/color27.jpg',
    'Images/color28.jpg',
    'Images/color29.jpg',
    'Images/DACIA.jpg',
    'Images/jaguar.jpg',
    'Images/Lamborghini.jpg',
    'Images/Lexus-Logo.jpg',
    'Images/masina.jpg',
    'Images/mecanic1.jpg',
    'Images/mecanic2.jpg',
    'Images/MERCEDES.jpg',
    'Images/mercedes2.jpg',
    'Images/porsche.png',
    'Images/seat.jpg',
    'Images/suzuki.jpg',
    'Images/volvo.jfif',
    'Images/vopsirea-masinii.jpg',
    'Images/Schimbare-anvelope.jpg',
    'Images/download.jpg',
    'Images/fiat.jfif',
    'Images/ford.jfif',
    'Images/forTatoo.jpg',
    'Images/Ioana.jpg',
    'Images/Ioana2.jpg',
    'Images/Ioana3.jpg',
    'Images/Larisa.png',
    'Images/Since 1999.png'
];


self.addEventListener('install', e => {
  console.log('Service Worker CAR: Installed');

  e.waitUntil(caches
      .open(cacheName)
      .then(cache => {
          console.log('SW CAR cache files');
          cache.addAll(cacheAssets);
      })
      .then(() => self.skipWaiting())
  );
});

self.addEventListener('activate', e => {
  console.log('Service Worker CAR: Activated');
  e.waitUntil(
      caches.keys().then(cacheNames => {
          return Promise.all(
              cacheNames.map(cache => {
                  if (cache !== cacheName) {
                      console.log('SW CAR:Cleaning Old Cache ');
                      return caches.delete(cache);
                  }
              })
          )
      })
  )
})

self.addEventListener('fetch', e => {
  console.log('SW CAR fetching');
  e.respondWith(fetch(e.request).catch(() => caches.match(e.request)));
})
// self.addEventListener('fetch', event => {
//     //We defind the promise (the async code block) that return either the cached response or the network one
//     //It should return a response object
//     const getCustomResponsePromise = async => {
//         console.log(`URL ${event.request.url}`, `location origin ${location}`)

//         try {
//             //Try to get the cached response
//             const cachedResponse = await caches.match(event.request)
//             if (cachedResponse) {
//                 //Return the cached response if present
//                 console.log(`Cached response ${cachedResponse}`)
//                 return cachedResponse
//             }

//             //Get the network response if no cached response is present
//             const netResponse = await fetch(event.request)
//             console.log(`adding net response to cache`)

//             //Here, we add the network response to the cache
//             let cache = await caches.open(CACHE_NAME)

//             //We must provide a clone of the response here
//             cache.put(event.request, netResponse.clone())

//             //return the network response
//             return netResponse
//         } catch (err) {
//             console.error(`Error ${err}`)
//             throw err
//         }
//     }

//     //In order to override the default fetch behavior, we must provide the result of our custom behavoir to the
//     //event.respondWith method
//     event.respondWith(getCustomResponsePromise())
// })

// // On install - caching the application shell
// self.addEventListener('install', function(event) {
//     event.waitUntil(
//       caches.open('sw-cache').then(function(cache) {
//         // cache any static files that make up the application shell
//         return cache.add('meniu.html');
//       })
//     );
//   });
  
//   // On network request
//   self.addEventListener('fetch', function(event) {
//     event.respondWith(
//       // Try the cache
//       caches.match(event.request).then(function(response) {
//         //If response found return it, else fetch again
//         return response || fetch(event.request);
//       })
//     );
//   });