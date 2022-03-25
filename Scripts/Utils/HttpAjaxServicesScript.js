
function HttpClientAjaxAsync(typeHttp, url, dataModel) {
    
     return new Promise((resolve, reject) => {

         var peticion = {
             method: typeHttp,
             url: url,
             data: JSON.stringify(dataModel),
             dataType: 'json',
             contentType: 'application/json; charset=utf-8',
         }

         $.ajax(peticion).done(function (data) {
             //alert("status 200 OK"); // imprimimos la respuesta
             console.log("status 200 OK");
             resolve(data)

         }).fail(function () {
             console.log("Algo salió mal");
             //alert("Algo salió mal");
         }).always(function () {
             //alert("Siempre se ejecuta")
         });

     });
     }
    
