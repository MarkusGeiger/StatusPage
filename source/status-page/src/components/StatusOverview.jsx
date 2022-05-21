import { Button, Col, Row, Space, Spin } from "antd";
import { useEffect, useState } from "react";
import StatusCard from "./StatusCard";

export function StatusOverview(props) {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState([]);

  // Note: the empty deps array [] means
  // this useEffect will run once
  // similar to componentDidMount()
  useEffect(() => {
    fetch("http://localhost:5284/api/status")
      .then(res => res.json())
      .then(
        (result) => {
          setIsLoaded(true);
          setItems(result);
          console.log("Status result: ", result);
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        (error) => {
          setIsLoaded(true);
          setError(error);
        }
      )
  }, [])

  const StatusCardSelected = (title, path, event) => {
    console.log("StatusCard " + title + " clicked! => " + path, event);
    props.onPathChanged([path, title]);
  }

  const OnRefresh = async (event) => {
    console.log("Refresh button clicked!");
  }

  return (
    <Row>
      <Col>
        <Button onClick={OnRefresh}>Refresh</Button>
      </Col>
      <Col>
        {/* <Spin tip="Loading..."></Spin> */}
        {isLoaded ? "Ready" : "Loading"}
      </Col>
      {isLoaded && items.map((item, index) =>
        <Col xs={24} sm={24} md={12} key={"Col" + index}>
          <StatusCard onClick={(title, event) => StatusCardSelected(title, "Overview", event)}
            title={item.name}
          />
        </Col>)}
    </Row>
  );
}