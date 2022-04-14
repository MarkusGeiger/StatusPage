import { Col, Row, Space } from "antd";
import StatusCard from "./StatusCard";

export function StatusOverview(){
    return (
        <Row>
            {new Array(15).fill(null).map((_item, index) => 
            <Col xs={24} sm={24} md={12} key={"Col"+index}>
                <StatusCard title={"Item " + index}/>
            </Col>)}
        </Row>
    );
}