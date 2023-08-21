var upload = document.getElementById('upload-image');
var fileOpener = document.getElementById('open-file');
var image = document.getElementById('main-image');

upload.onclick = function(event) {
    event.preventDefault();

    $('#open-file').click();
}

fileOpener.addEventListener('change', (e) => {
    const files = e.target.files;
    const countFiles = files.length;

    if (!countFiles) { 
        alert('Вы не выбрали файл');
        return;
    }
    
    const selectedFile = files[0];

    

    const reader = new FileReader();
    reader.readAsDataURL(selectedFile);
    reader.addEventListener('load', (e) => {
        image.src = e.target.result;
    });

    reader.addEventListener('error', () => {
        console.error(selectedFile.name);
    });
});