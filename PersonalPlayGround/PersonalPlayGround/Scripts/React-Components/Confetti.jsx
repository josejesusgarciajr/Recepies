function Confetti() {

    // Remove the confetti stylesheet after 3 seconds
    const timeout = setTimeout(() => {
        const stylesheet = document.getElementById('confettiStylesheet');
        if (stylesheet) {
            stylesheet.parentNode.removeChild(stylesheet);
        }

        clearTimeout(timeout);
    }, 2000);

    return null; // Render an empty div
}

ReactDOM.render(<Confetti />, document.getElementById('removeBackground'));