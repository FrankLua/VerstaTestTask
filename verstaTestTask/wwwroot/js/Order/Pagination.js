debugger
const allPageCount = Number.parseInt(document.getElementById("countPages").getAttribute('dataCountPage'))
let actualPage = Number.parseInt(document.getElementById("countPages").getAttribute('dataNumberActualPage'))
const paginationNav = document.getElementById('paginationBar');



if (actualPage >= 1) {
    paginationNav.appendChild(createNewBackButton(actualPage))
    paginationNav.appendChild(createNewLiButton(actualPage - 1))
    paginationNav.appendChild(createNewLiButton(actualPage ))
    paginationNav.appendChild(createNewLiButton(actualPage + 1))
    paginationNav.appendChild(createNewNextButton(actualPage+1))
}
if  (actualPage == 0) {    
    paginationNav.appendChild(createNewLiButton(actualPage))
    paginationNav.appendChild(createNewLiButton(actualPage + 1))
    paginationNav.appendChild(createNewLiButton(actualPage + 2))
    paginationNav.appendChild(createNewNextButton(actualPage+1))
}



function createNewLiButton(pageNumber) {
    
    let li = document.createElement('li');
    let a = document.createElement('a');   
    a.className = "page-link";
    if (pageNumber >= allPageCount) {
        a.style.pointerEvents = "none";
    }
    a.href = `/Order/Index?pageNumber=${pageNumber}`;
    a.innerText = pageNumber;
    li.className = "page-item";
    li.appendChild(a);
    return li;
}
function createNewNextButton(pageNumber) {
    let li = document.createElement('li');
    let a = document.createElement('a');
    a.className = "page-link";
    if (pageNumber >= allPageCount) {
        a.style.pointerEvents = "none";
    }
    a.href = `/Order/Index?pageNumber=${pageNumber}`;
    a.innerText = "Next";
    li.className = "page-item";
    li.appendChild(a);
    return li;
}
function createNewBackButton(pageNumber) {
    let li = document.createElement('li');
    let a = document.createElement('a');
    a.className = "page-link";
    a.href = `/Order/Index?pageNumber=${pageNumber - 1}`;
    a.innerText = "Back";
    li.className = "page-item";
    li.appendChild(a);
    return li;
}