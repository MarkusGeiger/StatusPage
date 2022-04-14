import { Card } from "antd";

function StatusCard(props) {
    return (
    <Card title={props.title} style={{margin: "5px"}}>
        <p>Up and running!</p>
    </Card>);
}

export default StatusCard;