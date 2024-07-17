

window.addEventListener("load", () => {
    var keyUri = document.getElementById("qrCodeKeyUri");
    new QRCode(document.getElementById("qrCode"), {
        text: keyUri.innerText,
        width: 160,
        height: 160
    })
});