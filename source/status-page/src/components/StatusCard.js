import { Card } from "antd";

function StatusCard(props) {
    return (
    <Card title={props.title} 
          style={{margin: "5px"}}
          onClick={(event) => props.onClick(props.title, event)}>
        <p>Up and running!</p>
    </Card>);
}

export default StatusCard;