const exampleModal = document.getElementById('exampleModal')
let buttonViewArray = document.getElementsByName('viewButton');
debugger
buttonViewArray.forEach((e) => {
    debugger
    e.addEventListener("click", (e) => {
        debugger
        const parentElement = e.currentTarget.parentElement.parentElement;
        let senderAddress = parentElement.getAttribute('dataAddressSender')
        let senderCity = parentElement.getAttribute('dataSenderCity')
        let rcipientAddress = parentElement.getAttribute('dataRecipientAddress')
        let recipientCity = parentElement.getAttribute('dataRecipientCity')
        let weight = parentElement.getAttribute('dataWeight')
        let date = parentElement.getAttribute('dataDateOrder')
        document.getElementById('viewSenderAddress').innerText = senderAddress;
        document.getElementById('viewSenderCity').innerText = senderCity;
        document.getElementById('viewRecipientAddress').innerText = rcipientAddress;
        document.getElementById('viewRecipientCity').innerText = recipientCity;
        document.getElementById('viewWeight').innerText = weight;
        document.getElementById('viewDate').innerText = date;
    })
});

if (exampleModal) {
  exampleModal.addEventListener('show.bs.modal', event => {
    // Button that triggered the modal
    const button = event.relatedTarget
    // Extract info from data-bs-* attributes
    const recipient = button.getAttribute('data-bs-whatever')
    // If necessary, you could initiate an Ajax request here
    // and then do the updating in a callback.

    // Update the modal's content.
    const modalTitle = exampleModal.querySelector('.modal-title')
    const modalBodyInput = exampleModal.querySelector('.modal-body input')

    modalTitle.textContent = `New message to ${recipient}`
    modalBodyInput.value = recipient
  })
}
