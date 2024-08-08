function mostrarRegistroAnimal() {
    const content = document.getElementById('content');
    content.innerHTML = `
    <div class="container bg-light">
        <div class="card-body ">
        <h2>Registrar Animal</h2>
        <form id="animalForm">
            <label for="especie">Especie:</label>
            <input "type="text" id="especie" name="especie" required>
            
            <label for="nombre">Nombre:</label>
            <input type="text" id="nombre" name="nombre" required>
            
            <label for="raza">Raza:</label>
            <input type="text" id="raza" name="raza" required>
            
            <label for="edad">Edad:</label>
            <input type="number" id="edad" name="edad" required>
            
            <label for="sexo">Sexo:</label>
            <input type="text" id="sexo" name="sexo" required>
            <br>
            <button class="btn btn-primary" type="submit">Registrar</button>
        </form>
        </div>
    </div>
    `;

    document.getElementById('animalForm').addEventListener('submit', async (e) => {
        e.preventDefault();
        const animal = {
            especie: document.getElementById('especie').value,
            nombre: document.getElementById('nombre').value,
            raza: document.getElementById('raza').value,
            edad: document.getElementById('edad').value,
            sexo: document.getElementById('sexo').value
        };

        try {
            const result = await postAnimal(animal);
            alert('Animal registrado correctamente');
            mostrarListaAnimal();
        } catch (error) {
            alert(`Error al registrar el animal: ${error.message}`);
        }
    });
}

async function mostrarListaAnimal() {
    const animals = await getAnimales();
    const content = document.getElementById('content');
    content.innerHTML = `
    <div class="container bg-light">
        <div class="card-body ">
        <h2>Lista de Animales</h2>
        <table class="table">
        <thead id="animalList"> 
        <tr>

        <th>Id</td>
        <th>Animal</td>
        <th>Dueño</td>
        <th>Opciones </td>
        
        </tr>
        </thead>
       
        </table>
        </div>
        </div>
    `;

    const animalList = document.getElementById('animalList');
    animals.forEach(async animal => {


        //const listItem = document.createElement('td');
        //listItem.className = "list-group-item list-group-item-action";
        const tr = document.createElement('tr');
        const td1 = document.createElement('td');
        const td2 = document.createElement('td');
        const td3 = document.createElement('td');
        const tda = document.createElement('td');

        if (animal.dueñoId == null) {
            td1.textContent = `${animal.id}`;
            td2.textContent = `${animal.nombre}`;
            td3.textContent = `No tiene dueño asignado`;
            //listItem.textContent = `${animal.id}) ${animal.nombre} - No tiene dueño Asignado`;
        } else {
            const dueño = await getDueños(animal.dueñoId);
            td1.textContent = `${animal.id}`;
            td2.textContent = `${animal.nombre}`;
            td3.textContent = `${dueño.nombre}`;
            //listItem.textContent = `${animal.id}) ${animal.nombre} - ${dueño.nombre}`;
        }
        // Boton detalle animal
        const actionsItem = document.createElement('a');
        actionsItem.className = "";
        actionsItem.textContent = 'Detalle';
        actionsItem.onclick = () => mostrarDetalleAnimal(animal.id);

        // Boton editar animal
        const actionItem = document.createElement('a');
        actionItem.className = '';
        actionItem.textContent = 'Editar';
        actionItem.onclick = () => mostrarEditarAnimal(animal.id);

        // Boton eliminar animal
        const action2Item = document.createElement('a');
        action2Item.className = "";
        action2Item.textContent = 'Eliminar';
        action2Item.onclick = () => mostrarEliminarAnimal(animal.id);


        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);

        tda.appendChild(actionsItem);
        tda.appendChild(actionItem);
        tda.appendChild(action2Item);
        tr.appendChild(tda);
        animalList.appendChild(tr);


    });
}

async function mostrarDetalleAnimal(id) {
    const animal = await getAnimal(id);
    const content = document.getElementById('content');
    content.innerHTML = `
    <div class="container bg-light">
    <div class="card-body ">
        <h2>Detalle del Animal</h2>
        <p>ID: ${animal.id}</p>
        <p>Nombre: ${animal.nombre}</p>
        <p>Especie: ${animal.especie}</p>
        <p>Raza: ${animal.raza}</p>
        <p>Edad: ${animal.edad}</p>
        <p>Sexo: ${animal.sexo}</p>
        <p>ID Dueño: ${animal.dueñoId}</p>
        <button class="btn btn-primary "onclick="mostrarListaAnimal()">Volver a la lista</button>
        </div>
        </div>
        `;
}

async function mostrarEliminarAnimal(id) {
    const animal = await getAnimal(id);
    const content = document.getElementById('content');
    content.innerHTML = `
    <div class="container bg-light">
    <div class="card-body ">
        <h2>Eliminar Animal</h2>
        <p>ID: ${animal.id}</p>
        <p>Nombre: ${animal.nombre}</p>
        <p>Especie: ${animal.especie}</p>
        <p>ID Dueño: ${animal.dueñoId}</p>
         <button class="btn btn-primary "onclick="verificarDeleteAnimal(${animal.id})">Eliminar Animal</button>
         <a class="btn btn-secondary "onclick="mostrarListaAnimal()">Volver a la lista</a>
    </div>
    </div>

    `
}

async function verificarDeleteAnimal(id) {
    const animalDel = await deleteAnimal(id);
    if (animalDel.isSuccess == true) {
        alert('Animal Eliminado Correctamente.');
    } else {
        alert('Error al Eliminar el Animal')
        throw new Error(animalDel.message);
    }
    mostrarListaAnimal();
}

async function mostrarEditarAnimal(id) {
    const animal = await getAnimal(id);
    const content = document.getElementById('content');
    content.innerHTML = `
    <div class="container bg-light">
        <div class="card-body ">
        <h2>Registrar Animal</h2>
        <form id="animalForm">
            <label for="especie">Especie:</label>
            <input "type="text" value="${animal.especie}" id="especie" name="especie" required>
            
            <label for="nombre">Nombre:</label>
            <input type="text" value="${animal.nombre}" id="nombre" name="nombre" required>
            
            <label for="raza">Raza:</label>
            <input type="text" value="${animal.raza}" id="raza" name="raza" required>
            
            <label for="edad">Edad:</label>
            <input type="number" value="${animal.edad}" id="edad" name="edad" required>
            
            <label for="sexo">Sexo:</label>
            <input type="text" value="${animal.sexo}" id="sexo" name="sexo" required>
            <br>
            <button class="btn btn-primary" type="submit">Guardar Cambios</button>
            <a class="btn btn-secondary "onclick="mostrarListaAnimal()">Volver a la lista</a>
        </form>
        </div>
    </div>
    `;
    document.getElementById('animalForm').addEventListener('submit', async (e) => {
        e.preventDefault();
        const animal = {
            especie: document.getElementById('especie').value,
            nombre: document.getElementById('nombre').value,
            raza: document.getElementById('raza').value,
            edad: document.getElementById('edad').value,
            sexo: document.getElementById('sexo').value
        };

        const result = await putAnimal(animal, id);
        if (result.isSuccess == true) {
            alert('Animal guardado correctamente.');
        } else {
            throw new Error(result.message);
        }

        mostrarListaAnimal();
    });
}
function vaciarContent() {
    const content = document.getElementById('content');
    content.textContent = ` `;
}