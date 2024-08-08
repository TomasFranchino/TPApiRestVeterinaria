const apiBaseUrls = 'https://localhost:7072/api/dueño';


async function getDueños(id) {
    const response = await fetch(`${apiBaseUrls}/GetDueño/${id}`);
    if (response.ok) {
        const dueño = await response.json();
        return dueño.data;
    } else {
        throw new Error("Error al obtener el dueño")
    }
}

