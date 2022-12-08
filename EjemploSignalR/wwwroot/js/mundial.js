var connection = new signalR.HubConnectionBuilder()
    .withUrl("/paisHub")
    .build();


connection.start()
    .then(function () {
        console.log("se establecio la conexion");
    })
    .catch(function (err) {
        console.error(err.message);
    })


connection.on("ReceiveResult", function (nombre, cantidadJugadores, esMundialista) {
    let li = document.createElement("li");
    if (esMundialista) {
        document.getElementById("listaMundialista").appendChild(li);
        li.innerHTML = `<strong>Nombre: </strong> ${nombre},<strong>Cantidad Jugadores</strong> : ${cantidadJugadores}`;
    } else {
        document.getElementById("listaNoMundialista").appendChild(li);
        li.innerHTML = `<strong>Nombre: </strong> ${nombre},<strong>Cantidad Jugadores</strong> : ${cantidadJugadores}`;
    }

    connection.invoke("EnviarMensaje", user, message)
        .catch(function (err) {
            console.error(err.message);
        })
})