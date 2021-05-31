import Vue from 'vue'
import Router from 'vue-router'

import CreateTask from '../pages/CreateTask.vue'
import AdminDash from '../pages/AdminDashboard.vue'


Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'AdminDashboard',
            component: AdminDash
        },
        {
            path: '/create',
            name: 'CreateTask',
            component: CreateTask
        }
       
        
    ] 
})