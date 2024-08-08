const apiBaseUrl = 'https://localhost:7072/api/animal';

async function postAnimal(animal) {
    const response = await fetch(`${apiBaseUrl}/PostAnimales`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(animal)
    });
    if (response.ok) {
        return response.json();
    } else {
        throw new Error("Error al crear el animal")
    }
}

async function getAnimales() {
    const response = await fetch(`${apiBaseUrl}/GeAnimales`);
    if (response.ok) {
        const animals = await response.json();
        return animals.data;
    } else {
        throw new Error('Error al consultar animales');
    }
}

async function getAnimal(id) {
    const response = await fetch(`${apiBaseUrl}/GetAnimal/${id}`);
    if (response.ok) {
        const animals = await response.json();
        return animals.data;
    } else {
        throw new Error("Error al obtener animal");
    }
}

async function deleteAnimal(id) {
    const response = await fetch(`${apiBaseUrl}/DeleteAnimal/${id}`, { method: 'Delete' });
    if (response.ok) {
        const resp = await response.json();
        return resp;
    } else {
        throw new Error("Error al eliminar animal")
    }
}

async function putAnimal(animal, id) {
    const response = await fetch(`${apiBaseUrl}/PutAnimal/${id}`, {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(animal)
    });
    if (response.ok) {
        return response.json();
    } else {
        throw new Error("Error al actualizar animal")
    }

}