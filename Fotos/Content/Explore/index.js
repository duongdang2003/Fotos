﻿let imageIndex = 0;
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
function Post(title, description, coverSrc, imageSrcList) {
    const imgSrc = coverSrc.replace(/ /g, "%20")
    console.log(imageSrcList.toString().replace(/ /g, "%20"))
    return `
        <div class="card my-2" style="width: 30rem; border: none" name="card" >
                <img src=${imgSrc} class="card-img-top post" data-bs-toggle="modal" data-bs-target="#imageSlider" imgssrc=${imageSrcList.toString().replace(/ /g, "%20")}>
                <div class="card-body">
                    <div class="d-flex mb-1">
                        <div class="d-flex align-items-center like-group" status="nolike">
                            <div class="like-btn" >
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart" viewBox="0 0 16 16" like="false">
                                    <path d="m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143q.09.083.176.171a3 3 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15" />
                                </svg>
                            </div>
                            
                            <div class="mx-1">1k</div>
                        </div>
                        <div class="d-flex align-items-center mx-3">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-chat" viewBox="0 0 16 16">
                                <path d="M2.678 11.894a1 1 0 0 1 .287.801 11 11 0 0 1-.398 2c1.395-.323 2.247-.697 2.634-.893a1 1 0 0 1 .71-.074A8 8 0 0 0 8 14c3.996 0 7-2.807 7-6s-3.004-6-7-6-7 2.808-7 6c0 1.468.617 2.83 1.678 3.894m-.493 3.905a22 22 0 0 1-.713.129c-.2.032-.352-.176-.273-.362a10 10 0 0 0 .244-.637l.003-.01c.248-.72.45-1.548.524-2.319C.743 11.37 0 9.76 0 8c0-3.866 3.582-7 8-7s8 3.134 8 7-3.582 7-8 7a9 9 0 0 1-2.347-.306c-.52.263-1.639.742-3.468 1.105" />
                            </svg>
                            <div class="mx-1">125</div>
                        </div>
                    </div>
                    <h5 class="card-title">${title}</h5>
                    <p class="card-text">${description}</p>
                </div>
        </div>
    `
}
function CarouselItem(src) {
    return `
        <div class="carousel-item d-flex justify-content-center">
           <img src=${src} class="d-block" alt="..." style="max-height: 80vh">
        </div>
    `
}
function ActiveCarouseItem(src) {
    return `
        <div class="carousel-item active d-flex justify-content-center">
           <img src=${src} class="d-block" alt="..." style="max-height: 80vh">
        </div>
    `
}
function CreateNewPostOfUser(user) {
    user.Albums.forEach((album) => {
        $("#content").append(Post(album.AlbumName, "Description", album.Images[0], album.Images));
    })
}
function HandleModel() {
    console.log("Click");
}
function HandleLike() {
    const status = $(this).attr("like");
    $(this).children(".bi-heart").remove();
    console.log("click")
}
function GetUserID() {
    return new Promise((resolve, reject) => {
        var xhr = new XMLHttpRequest();
        xhr.open('POST', 'https://localhost:44374/Albums/GetAlbumsByUserId', true);

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
    users.forEach((user) => {
        console.log(user)
        CreateNewPostOfUser(user);
    })
    $(".post").click(function () {
        $("#slider-content").empty();
        const imgList = $(this).attr('imgssrc').split(",")
        console.log(imgList)
        $("#slider-content").append(ActiveCarouseItem(imgList[0]));
        for (i = 1; i < imgList.length; i++) {
            $("#slider-content").append(CarouselItem(imgList[i]))
        }
        //imgList.forEach((imgSrc) => {
        //    $("#slider-content").append(CarouselItem(imgSrc))
        //})
    })
    $(".like-group").on("click", function () {
        if ($(this).attr("status") == "nolike") {
            $(this).find("svg").replaceWith(`<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart-fill" viewBox="0 0 16 16"><path fill-rule="evenodd" d="M8 1.314C12.438-3.248 23.534 4.735 8 15-7.534 4.736 3.562-3.248 8 1.314" /></svg > `)
            $(this).attr("status", "like")
        }
        else {
            $(this).find("svg").replaceWith(`<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart" viewBox="0 0 16 16" like="false"><path d="m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143q.09.083.176.171a3 3 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15" /></svg>`)
            $(this).attr("status", "nolike")
        }
    })
})
