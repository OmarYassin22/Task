const handleAdd = () => {
    document.getElementById('addForm').style.display = 'block';
}
const handleSubmit = (e) => {

    e.target.submit();

}
const myModal = document.getElementById('myModal')
const myInput = document.getElementById('myInput')

myModal?.addEventListener('shown.bs.modal', () => {
    myInput.focus()
})

const handleDelete = (event) => {
    debugger;
    event.preventDefault();
    const confirmDelete = confirm('Are you sure you want to delete this applicant?');
    if (confirmDelete) {
        event.target.submit();
    }
}