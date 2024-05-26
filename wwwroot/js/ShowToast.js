window.showToast = () => {
    console.log("Show Toast");
    const toastObj = document.getElementById('bootstrapToast');
    if (toastObj != null) {
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastObj);
        console.log("toast executed");
        toastBootstrap.delay = 3000;
        toastBootstrap.show();
    }

}