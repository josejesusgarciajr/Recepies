const ImagePreview = ({ selectedFile }) => {
    let previewUrl = '';
    if (selectedFile) {
        previewUrl = URL.createObjectURL(selectedFile);
    }

    return (
        <div>
            {selectedFile && (
                <div>
                    <p class="lead"><code>PREVIEW:</code> {selectedFile.name}</p>
                    <img src={previewUrl} alt="File Preview" style={{ width: '100%', height: '560px' }} />
                </div>
            )}
        </div>
    );
};

ReactDOM.render(<ImagePreview />, document.getElementById('uploadImageId'));