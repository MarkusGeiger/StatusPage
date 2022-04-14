import { Layout, Menu, Breadcrumb } from 'antd';
import './BaseLayout.css';
import { StatusOverview } from './StatusOverview';

const { Header, Content, Footer } = Layout;

export function BaseLayout (){
    return (<Layout className="layout">
      <Header>
        <div className="logo" />
        {/* <Menu theme="dark" mode="horizontal" defaultSelectedKeys={['2']}>
          {new Array(15).fill(null).map((_, index) => {
            const key = index + 1;
            return <Menu.Item key={key}>{`nav ${key}`}</Menu.Item>;
          })}
        </Menu> */}
      </Header>
      <Content style={{ padding: '0 10px' }}>
        <Breadcrumb style={{ margin: '16px 0' }}>
          <Breadcrumb.Item>Home</Breadcrumb.Item>
          {/* <Breadcrumb.Item>List</Breadcrumb.Item> */}
          {/* <Breadcrumb.Item>App</Breadcrumb.Item> */}
        </Breadcrumb>
        <div className="site-layout-content"><StatusOverview/></div>
      </Content>
      <Footer style={{ textAlign: 'center' }}>Ant Design ©2018 Created by Ant UED</Footer>
    </Layout>);
    }