import { Layout, Menu, Breadcrumb } from 'antd';
import { useState } from 'react';
import './BaseLayout.css';
import { StatusOverview } from './StatusOverview';

const { Header, Content, Footer } = Layout;

export function BaseLayout (){
  var [path, setPath] = useState(["Home"]);

  function PathChanged(newPath){
    console.log("Path has changed to: ", ["Home"].concat(newPath));
    setPath(["Home"].concat(newPath));
  }

    return (<Layout className="layout">
      <Header>
        <div className="logo" />
        StatusPage
        {/* <Menu theme="dark" mode="horizontal" defaultSelectedKeys={['2']}>
          {new Array(15).fill(null).map((_, index) => {
            const key = index + 1;
            return <Menu.Item key={key}>{`nav ${key}`}</Menu.Item>;
          })}
        </Menu> */}
      </Header>
      <Content style={{ padding: '0 10px' }}>
        <Breadcrumb style={{ margin: '16px 0' }}>
          {path && path.map((item) => <Breadcrumb.Item>{item}</Breadcrumb.Item>)}
          {/* <Breadcrumb.Item>List</Breadcrumb.Item> */}
          {/* <Breadcrumb.Item>App</Breadcrumb.Item> */}
        </Breadcrumb>
        <div className="site-layout-content"><StatusOverview onPathChanged={PathChanged}/></div>
      </Content>
      <Footer style={{ textAlign: 'center' }}>Ant Design ©2018 Created by Ant UED</Footer>
    </Layout>);
    }