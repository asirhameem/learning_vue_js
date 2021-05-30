import Vue from 'vue'
import Router from 'vue-router'


import AdminDash from '../pages/AdminDashboard.vue'


Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'AdminDashboard',
            component: AdminDash

        }
       
        
    ]
})