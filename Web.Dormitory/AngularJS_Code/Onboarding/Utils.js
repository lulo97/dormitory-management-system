function waitForToastAfterGoToDashboard(window) {
    setTimeout(() => {
       window.location.href = '/Dashboard';
    }, 1000); // Adjust the delay time as needed (in milliseconds)
}