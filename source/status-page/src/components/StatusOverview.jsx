import { Col, Row, Space } from "antd";
import StatusCard from "./StatusCard";

export function StatusOverview(props){

    const StatusCardSelected = (title, path, event) => {
        console.log("StatusCard " + title + " clicked! => " + path, event);
        props.onPathChanged([path, title]);
    }

    return (
        <Row>
            {new Array(15).fill(null).map((_item, index) => 
            <Col xs={24} sm={24} md={12} key={"Col"+index}>
                <StatusCard onClick={(title, event) => StatusCardSelected(title, "Overview", event)} 
                            title={"Item " + index}
                            />
            </Col>)}
        </Row>
    );
}