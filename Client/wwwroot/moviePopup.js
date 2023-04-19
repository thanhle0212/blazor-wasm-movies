export function showVideoPopup(videoId) {
    // Set the video URL
    var videoUrl = "https://www.youtube.com/embed/" + videoId + "?autoplay=1";
    var iframe = document.createElement("iframe");
    iframe.setAttribute("src", videoUrl);
    iframe.setAttribute("width", 820);
    iframe.setAttribute("height", 445);
    iframe.setAttribute("allowfullscreen", "");
    // iframe.classList.add("video-popup-iframe");

    var closeButton = document.createElement("span");
    closeButton.innerHTML = "&times;";
    closeButton.classList.add("video-popup-close");
    closeButton.addEventListener("click", function () {
        closePopup(popupOverlay);
    });

    var popupContainer = document.createElement("div");
    popupContainer.classList.add("video-popup-container");
    popupContainer.appendChild(closeButton);
    popupContainer.appendChild(iframe);

    var popupOverlay = document.createElement("div");
    popupOverlay.classList.add("video-popup-overlay");
    popupOverlay.appendChild(popupContainer);

    document.body.appendChild(popupOverlay);
  }

  function closePopup(popup) {
    popup.classList.remove("active");
    document.body.style.overflow = "auto";
    popup.innerHTML = "";

    popup.remove();
  }