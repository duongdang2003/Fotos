const contentContainer = $("#content");
function GetAllImages() {
    return new Promise((resolve, reject) => {
        var xhr = new XMLHttpRequest();
        xhr.open('GET', 'https://localhost:44363/Home/GetAllImages', true);

        xhr.onreadystatechange = function () {
            if (xhr.readyState === XMLHttpRequest.DONE) {
                if (xhr.status === 200) {
                    var response = JSON.parse(xhr.responseText);
                    if (response.success) {
                        resolve(response.users);
                    } else {
                        reject('Error: ' + response.message);
                    }
                } else {
                    reject('Error: ' + xhr.responseText);
                }
            }
        };

        xhr.send();
    });
}
GetAllImages().then(users => {
    console.log(users[0])
})