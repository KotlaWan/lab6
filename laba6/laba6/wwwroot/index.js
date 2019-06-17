const PORT = 50005;
// const PORT = 19699;
const HOST = `http://localhost:${PORT}`;
const headers = new Headers({
    'MS-ASPNETCORE-TOKEN': '8554a1c8-0840-49b5-8f23-a4a8c6fbfc76',
    'Content-ClassType': 'application/json',
    'cache-control': 'no-cache',
    'Postman-Token': '021d1188-96f2-4181-b5b6-fc48939e1db1',
});
const mode = 'cors';
const credentials = 'include';
const option = {
    headers,
    // mode,
    // credentials,
};

let fuels = [];
let ID = 0;
let Classes = [];

document.querySelector('[name="save"]').onclick = async () => {

    //const typeInput = document.querySelector('#type');
    //const priceInput = document.querySelector('#price');
    //const dateInput = document.querySelector('#date');
    //const hiddenInput = document.querySelector('#hidden');
    const select = document.querySelector('.select');

    const body = {
        ClassTypeId: select.options[select.selectedIndex].value,
        Classes: Classes.map(Class => {
            const input = document.querySelector(`#id_${Class.id}`);
            return {
                id: Class.id,
                value: input.value,
            }
        }),
    }
    try {
        await fetch(`${HOST}/api/gsms/${ID}`, {
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(body),
            method: 'PUT',
        });
        await updateTable();
    } catch (err) {
        alert('error');
    }
};

document.querySelector('[name="add"]').onclick = async () => {
    const input = document.querySelector('#added');
    const select = document.querySelector('.select');

    const body = {
        id: select.options[select.selectedIndex].value,
        value: input.value
    };

    try {
        await fetch(`${HOST}/api/gsms/`, {
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(body),
            method: 'POST',
        });
        await updateTable();
    } catch (err) {
        alert('error');
    }
}

document.querySelector('[name="delete"]').onclick = async () => {
    const divClasses = document.querySelector('.Classes');
    //const typeInput = document.querySelector('#type');
    //const priceInput = document.querySelector('#price');
    //const dateInput = document.querySelector('#date');
    //const hiddenInput = document.querySelector('#hidden');
    const select = document.querySelector('.select');
    try {
        await fetch(`${HOST}/api/gsms/${select.options[select.selectedIndex].value}`, {
            headers: {
                'Content-Type': 'application/json',
            },
            method: 'DELETE',
        });
        await updateTable();
        //typeInput.value = '';
        //priceInput.value = '';
        //dateInput.value = '';
    } catch (err) {
        alert('error');
    }
};

async function updateView(id) {
    ID = id;
    //const typeInput = document.querySelector('#type');
    //const priceInput = document.querySelector('#price');
    //const dateInput = document.querySelector('#date');
    //const hiddenInput = document.querySelector('#hidden');
    const divClasses = document.querySelector('.Classes');
    divPrices.innerHTML = '';
    const select = document.querySelector('.select');
    //const divDates = document.querySelector('.dates');
    try {
        const result = await fetch(`${HOST}/api/gsms/${id}`);
        const data = await result.json();

        Classes = data;
        //select.options.forEach(option => {
        //    //const option = document.createElement('option');
        //    //option.innerText = fuel.type;
        //    //option.value = fuel.id;
        //    //if (option.value === id) option.selected = true;
        //    console.log(option.value)
        //});
        select.selectedIndex = fuels.findIndex(fuel => fuel.id === id);

        //typeInput.value = data.type;
        const fragment = document.createDocumentFragment();
        data.forEach((Class) => {
            const input = document.createElement('input');
            input.ClassType = 'text';
            input.className = 'form-control mb-3';
            input.id = `id_${price.id}`;
            input.value = price.cost;
            fragment.appendChild(input);
        });
        divClasses.appendChild(fragment);
        //priceInput.value = data.price;
        //const date = new Date(data.date);
        //dateInput.value = date.toLocaleDateString();//`${date.getFullYear()}-${date.getMonth()}-${date.getDate()}`;
        //hiddenInput.value = id;
    } catch (err) {
        alert('error');
    }
}

async function updateTable() {
    const table = document.querySelector('.table');
    const select = document.querySelector('.select');
    const divClasses = document.querySelector('.prices');
    divClasses.innerHTML = '';
    const inputForAdded = document.createElement('input');
    inputForAdded.ClassType = 'text';
    inputForAdded.className = 'form-control mb-3';
    inputForAdded.id = 'added';
    divClasses.appendChild(inputForAdded);

    table.innerHTML = '';
    select.innerHTML = '';
    try {        
        const result = await fetch(`${HOST}/api/gsms`);
        const data = await result.json();

        const fragment = document.createDocumentFragment();
        const fragmentOptions = document.createDocumentFragment();
        fuels = data;
        data.forEach(fuel => {
            const option = document.createElement('option');
            option.innerText = fuel.ClassType;
            option.value = fuel.id;
            fragmentOptions.appendChild(option);

            const tr = document.createElement('tr');
            const td1 = document.createElement('td');
            const td2 = document.createElement('td');
            const button = document.createElement('button');
            button.innerText = 'View';
            button.className = 'btn btn-info';
            button.onclick = () => updateView(fuel.id);

            td1.innerText = fuel.ClassType;
            td2.appendChild(button);
            tr.appendChild(td1);
            tr.appendChild(td2);
            fragment.appendChild(tr);
        });
        select.appendChild(fragmentOptions);
        table.appendChild(fragment);
    } catch (err) {
         alert("error");
    }
}

updateTable();
