const RangeNumber = ({ currentValue }) => {
    return (
        <div>
            <h1>{currentValue}</h1>
        </div>
    );
};

ReactDOM.render(<RangeNumber />, document.getElementById('ratingRangeNumber'));