const modal = document.getElementById("modal");
const btnCloseModal = document.getElementById("btnCloseModal");
const btnAdd = document.getElementById("btnAdd");

const toggleModalDisplay = () => {
     modal.style.display = modal.style.display === "flex" ? "none": "flex";  
}
btnCloseModal.addEventListener("click", (e) => {
    toggleModalDisplay();
});

btnAdd.addEventListener("click",()=>{
    toggleModalDisplay();
});


