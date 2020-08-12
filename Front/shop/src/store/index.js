import mutations from './mutations'

import Vue from 'vue'
import Vuex from 'vuex'
import VuexPersist from 'vuex-persist';
import axios from 'axios'
import { parseJwt ,Sort,SortAllItems ,SortUser} from "./func"
import router from '../router'
import swal from 'sweetalert'
import moment from 'moment'
//import $ from 'jquery'
import {HubConnectionBuilder} from '@aspnet/signalr'

// 2b9a7e2a-c0d1-4503-b3a4-08d7da39cb9e - айди комплекса
Vue.use(Vuex)

const vuexLocalStorage = new VuexPersist({
  key: 'vuex', 
  storage: window.localStorage, 
})

var port = 'http://84.201.133.212'
port ='http://localhost:5555'

export default new Vuex.Store({
  state: {
    openMenu:false,
    token: null,
    AllAboutToken:null,
    user:null,
    userName:null,
    categories:[],
    items:[],
    item:null,
    category:{},
    myItems:[],
    orders:[],
    recoms:[],
    comments:[],
    allComments:[],
    users:[],
    news:[],
    events:[],
    isEmail:false
  },
  mutations,
  actions: {
    

    async AddLike(state,form){
      if(this.state.isEmail ==false){
        await  this.dispatch("Author",this.state.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']) 
         if(this.state.isEmail ==false){
          swal({
            title: "Вам нужно подтвердить Email",
            icon: "info",
            buttons: ["Выйти", "Отправить письмо с подтверждением"],
          })
          .then((willDelete) => {
            if (willDelete) {
              this.dispatch("SendEmail")
              swal({
                text: "На " + this.state.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] +" было отправлено письмо. Перейдите и подтвердите ваш email",
                icon: "success",
              });
            } 
          });
         }
       }
       else{
      await this.dispatch("CheckRefresh")
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      const data={
        'reviewId':form.id,
        'type':form.type,
        'userId':this.state.user.sub}
      await axios.put(port+'/api/like',data,config).then(response =>{
         console.log(response)
        this.dispatch("GetCommentsByItem"); 
          })
        }
      },

    async AddRating(state,item){
      if(this.state.isEmail ==false){
        await  this.dispatch("Author",this.state.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']) 
         if(this.state.isEmail ==false){
          swal({
            title: "Вам нужно подтвердить Email",
            icon: "info",
            buttons: ["Выйти", "Отправить письмо с подтверждением"],
          })
          .then((willDelete) => {
            if (willDelete) {
              this.dispatch("SendEmail")
              swal({
                text: "На " + this.state.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] +" было отправлено письмо. Перейдите и подтвердите ваш email",
                icon: "success",
              });
            } 
          });
         }
       }
       else{
      await this.dispatch("CheckRefresh")
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      const data={
        'itemId':item.id,
        'star':item.top,
        'userId':this.state.user.sub}
      await axios.post(port +'/api/rating',data,config).then(response =>{
        this.dispatch("GetItems"); console.log(response)
        this.dispatch("GetItemById",item.id); 
        swal({
          text: "Ваш голос был учтен",
          icon: "success",
          });
          })
        }
      
      },

      ///Все что связано с событиями///////////////////////////////////////////////////////////////////////////////////
      async GetEvents(){
        await axios.get(port+'/api/event/').then(response => {
        this.commit("setEvents",response.data.reverse())
        console.log(response.data)
    }).catch(function (e) {console.log(e)});

      },
      async DeleteEvent(state,id){ 
        await this.dispatch("CheckRefresh") 
        var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
        await axios.delete(port +'/api/event/'+id,config);
        this.dispatch("GetEvents") 
  },
  
      async EditEvent(state,item){
        await this.dispatch("CheckRefresh") 
        var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
        var data = { 
          'id':item.id,  
          "text":item.text,
          "date":item.date}
        await axios.put(port +'/api/event/',data,config).then(response => {
          console.log(response)
          this.dispatch("GetEvents") 
        }).catch(function (error) {console.log(error)});
      },
  
      async AddEvent(state,item){
        await this.dispatch("CheckRefresh") 
        var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
        var data = { 
          "text":item.text,
          "date":item.date}
        await axios.post(port +'/api/event/',data,config).then(response => {
          console.log(response)
          this.dispatch("GetEvents") 
        }).catch(function (error) {console.log(error)});
      },

      ///Все что связано с новостями///////////////////////////////////////////////////////////////////////////////////
      async GetNews(){
        await axios.get(port +'/api/news/').then(response => {
        this.commit("setNews",response.data.reverse())
        console.log(response.data)
    }).catch(function (error) {console.log(error)});
      },
      async DeleteNews(state,id){ 
        await this.dispatch("CheckRefresh") 
        var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
        await axios.delete(port +'/api/news/'+id,config);
        this.dispatch("GetNews") 
  },
  
      async EditNews(state,item){
        await this.dispatch("CheckRefresh") 
        var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
        var data = { 
          'id':item.id,  
          "img":item.img,
          "link":item.link,
          "text":item.text}
        await axios.put(port +'/api/news/',data,config).then(response => {
          console.log(response)
          this.dispatch("GetNews") 
        }).catch(function (error) {console.log(error)});
      },
  
      async AddNews(state,item){
        await this.dispatch("CheckRefresh") 
        var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
        var data = { 
          "img":item.img,
          "link":item.link,
          "text":item.text}
        await axios.post(port+'/api/news/',data,config).then(response => {
          console.log(response)
          this.dispatch("GetNews") 
        }).catch(function (error) {console.log(error)});
      },
  
      //Все что связано с коментариями//////////////////////////////////////////////////////////////////////////////////
      async DeleteComment(state,id){ 
        await this.dispatch("CheckRefresh")  
        var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
        await axios.delete(port +'/api/chat/'+id,config);
        this.dispatch("GetCommentsByItem") 
      },
  
      async AddComment(state,text){
        console.log("ща текст " +text);
          if(this.state.isEmail ==false){
            await  this.dispatch("Author",this.state.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']) 
             if(this.state.isEmail ==false){
              swal({
                title: "Вам нужно подтвердить Email",
                icon: "info",
                buttons: ["Выйти", "Отправить письмо с подтверждением"],
              })
              .then((willDelete) => {
                if (willDelete) {
                  this.dispatch("SendEmail")
                  swal({
                    text: "На " + this.state.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] +" было отправлено письмо. Перейдите и подтвердите ваш email",
                    icon: "success",
                  });
                } 
              });
             }
           }
           else{
            
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      const data={
          'img': null,
          'text': text,
          'userId': this.state.user.sub,
          'itemId': this.state.item.id
      }
      await axios.post(port +'/api/chat/',data , config).then(response =>{
        this.dispatch("GetCommentsByItem") 
        console.log(response)})
          .catch(function(e){console.log(e); }); 
    
  }  
     },
     async GetCommentsByItem(){
      await axios.get(port +'/api/chat/item/'+this.state.item.id).then(response => {
      this.commit("setComments",response.data.reverse())
      console.log(response.data)
  }).catch(function (error) {console.log(error)});
    },

    async GetComments(){
      await axios.get(port +'/api/chat/').then(response => {
      this.commit("setAllComments",response.data.reverse())
      console.log(response.data)
  }).catch(function (error) {console.log(error)});
    },

    Connection({dispatch}){
      console.log(HubConnectionBuilder)
     let hubUrl = port +'/authchat'; //ссылка, по которому будем обращаться к хабу
      let connection = new HubConnectionBuilder() //создаем соединение с хабом и передаем токен
          .withUrl(hubUrl, { accessTokenFactory: () => this.state.AllAboutToken.accessToken })
          .build();

      this.connectionId =connection
      connection.on('Send', function (name, message ,userId ,itemId ) {
          if(message !=0){
            dispatch("GetCommentsByItem")
            console.log(message)
            console.log(name)
            console.log(itemId )
        }
      });
      connection.start();
    },

    //Все что связано с заказами//////////////////////////////////////////////////////////////////////////////////
    async EditOrder(state,or){
      await this.dispatch("CheckRefresh")
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      var data = {
          'show': or.show,
          'id':or.id,
          'status' : or.status,
          'userId': or.userId,}
      await axios.put(port +'/api/order',data,config).then(response => {
        console.log(response)
      }).catch(function (error) {console.log(error)});
      this.dispatch("GetOrders")     
    },
    
    async DeleteOrder(state,id){ 
      await this.dispatch("CheckRefresh")  
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      await axios.delete(port +'/api/order/'+id,config);
      this.dispatch("GetOrders") 
    },

    async AddOrder({dispatch}){
      await this.dispatch("CheckRefresh")
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      if(this.state.isEmail ==false){
        await  this.dispatch("Author",this.state.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']) 
         if(this.state.isEmail ==false){
          swal({
            title: "Вам нужно подтвердить Email",
            icon: "info",
            buttons: ["Выйти", "Отправить письмо с подтверждением"],
          })
          .then((willDelete) => {
            if (willDelete) {
              dispatch("SendEmail")
              swal({
                text: "На " + this.state.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] +" было отправлено письмо. Перейдите и подтвердите ваш email",
                icon: "success",
              });
            } 
          });
         }
       }
       else{
      const data={
        'show':true,
        'status':"в процесе",
        'userId':this.state.user.sub}
      await axios.post(port +'/api/order',data,config).then(response =>{
          this.state.myItems.forEach(e => {
            if(e.status ==true){
              e.orderId = response.data.id
              e.status = false
              this.dispatch("EditMyItem",e) 
            }
            this.dispatch("GetOrders")
          })
        })
      }
    },
    async GetOrders(){
      await this.dispatch("CheckRefresh")
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      await axios.get(port +'/api/order/user/'+this.state.user.sub,config).then(response =>{
      this.commit("setOrders",Sort(response.data))
    }).catch(function (error) {console.log(error)});
    },
  

    async GetAllOrders(){
      let orders
      await this.dispatch("CheckRefresh")
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      await axios.get(port +'/api/order/',config).then(response =>{
         orders = Sort(response.data)
         console.log(response.data)
    }).catch(function (error) {console.log(error)});
    return orders
    },



    //Все что связано с покупками//////////////////////////////////////////////////////////////////////////////
    async GetMyItems(){
      await this.dispatch("CheckRefresh")
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
          await axios.get(port +'/api/useritem/useritems/'+this.state.user.sub ,config).then(response =>{
            console.log(response.data)
          this.commit("setMyItems",Sort(response.data))
        }).catch(function (error) {console.log(error)});
    },

    async AddMyItem(state,id){
        await this.dispatch("CheckRefresh")
        var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
        const data={
            'status':false,
            'userId':this.state.user.sub,
            'itemId': id,
            'value':+1}
        await axios.post(port +'/api/useritem/',data,config).then(response =>{
          console.log(response)
          this.dispatch("GetMyItems") })
          .catch(function (error) {console.log(error)});      
  },

  async DeleteMyItem(state,id){ 
        await this.dispatch("CheckRefresh") 
        var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
        await axios.delete(port +'/api/useritem/'+id,config);
        this.dispatch("GetMyItems") 
  },

  async EditMyItem(state,myItem){
    await this.dispatch("CheckRefresh")
    var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
    var data = { 
        'id':myItem.id,
        'status' : myItem.status,
        'userId': myItem.userId,
        "itemId":myItem.itemId,
        "value": myItem.value,
        'orderId': myItem.orderId
      }
    await axios.put(port+'/api/useritem',data,config).then(response => {
      console.log(response)
    }).catch(function (error) {console.log(error)});
    this.dispatch("GetMyItems")     
  },

   
    //Все что связано с категориями////////////////////////////////////////////////////////////////////////////////////////////////////
    async GetCategories(){
      await axios.get(port +'/api/category').then(response => {
        this.commit("setCategories",response.data)
      }).catch(function (error) {console.log(error)});  
    },
    async DeleteCategory(state,id){ 
      await this.dispatch("CheckRefresh") 
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      await axios.delete(port +'/api/category/'+id,config);
      this.dispatch("GetCategories") 
      this.dispatch("GetItems") 
},

    async EditCategory(state,item){
      await this.dispatch("CheckRefresh") 
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      var data = { 
        "name":item.name,
        'id':item.id,
        "img":item.img}
      await axios.put(port +'/api/category/',data,config).then(response => {
        console.log(response)
        this.dispatch("GetCategories") 
      }).catch(function (error) {console.log(error)});
    },

    async AddCategory(state,item){
      await this.dispatch("CheckRefresh") 
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      var data = { 
        "name":item.name,
        "img":item.img}
      await axios.post(port +'/api/category/',data,config).then(response => {
        console.log(response)
        this.dispatch("GetCategories") 
      }).catch(function (error) {console.log(error)});
    },

    //Все что связано с товарами///////////////////////////////////////////////////////////////////////////////////////////////////
     async DeleteItem(state,id){ 
      await this.dispatch("CheckRefresh") 
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      await axios.delete(port +'/api/item/'+id,config);
      this.dispatch("GetItems") 
},

    async EditItem(state,item){
      await this.dispatch("CheckRefresh") 
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      var data = { 
        "name":item.name,
        'id':item.id,
        'status' : item.status,
        'categoryId': item.categoryId,
        "img":item.img,
        "cost": item.cost,
        'komplex': item.komplex,
        "text":item.text,
        "grams":item.grams,
        "views":0}
      await axios.put(port +'/api/item/',data,config).then(response => {
        console.log(response)
        this.dispatch("GetItems") 
      }).catch(function (error) {console.log(error)});
    },

    async AddItem(state,item){
      await this.dispatch("CheckRefresh") 
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      var data = { 
        "name":item.name,
        'status' : item.status,
        'categoryId': item.categoryId,
        'grams':item.grams,
        "img":item.img,
        "cost": item.cost,
        'komplex': item.komplex,
        "text":item.text,
        "views":0}
      await axios.post(port +'/api/item/',data,config).then(response => {
        console.log(response)
        this.dispatch("GetItems") 
      }).catch(function (error) {console.log(error)});
    },


    async GetItemById(state,id){
      await axios.get(port +'/api/item/'+id).then(response => {
            this.commit("setItem",response.data)
          }).catch(function (error) {console.log(error)});
      },

    async GetItems(state,idCategory){
      if(idCategory==null){
        await axios.get(port+'/api/item').then(response => {
          this.commit("setItems",SortAllItems(response.data))
          console.log(response.data)
        }).catch(function(e){console.log(e)});
        }
      },

        async GetCoolRecoms(){
        const data={
        'userItems':this.state.myItems.filter(e => e.orderId ==null),
        'userId':this.state.user.sub}
      await axios.post(port+'/api/useritem/recom',data).then(response =>{
     
     
        console.log("kfhjd")
        this.commit("setRecoms",response.data.filter(e=>e.status==true))
       
        console.log(response)
          })
      },

    //Все что связано с авторизацией и пользователями//////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    async DeleteUser(state,id){ 
      await this.dispatch("CheckRefresh") 
      var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
      await axios.delete(port+'/api/user/'+id,config);
      this.dispatch("GetUsers") 
  },
      async GetUsers(){
        await this.dispatch("CheckRefresh")
        //var config ={headers:{ Authorization :"Bearer "+ this.state.AllAboutToken.accessToken}}
            await axios.get(port +'/api/user/').then(response =>{
              console.log(response.data)
            this.commit("setUsers",SortUser(response.data))
          }).catch(function (error) {console.log(error)});

      },


    async Register(state,data){   
      await axios.post(port +'/api/register',data).then(response =>{
          console.log(response)
          this.commit('setAllToken',response.data.data)
          this.commit("setUser",parseJwt(this.state.AllAboutToken.accessToken))
          this.dispatch("Author",this.state.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'])  
          swal({
            text: "На " + data.email +" было отправлено письмо. Перейдите и подтвердите ваш email",
            icon: "info",
          });
          router.push('/')
        }).catch(
          function (error) {
            swal({
              text: "Такой Email уже используется",
              icon: "info",
              });
          console.log(error)});
        //this.Connection()
    },
    
    async CheckRefresh(){
      if(this.state.AllAboutToken !=null){
        console.log(moment.unix(this.state.AllAboutToken.expiresIn))
       
        if(moment.unix(this.state.AllAboutToken.expiresIn) <= moment()){
           await this.dispatch("RefreshToken")
        }
      
      }
    },



    async RefreshToken(){
      const data={
            'refreshToken':this.state.AllAboutToken.refreshToken ,
            'accessToken': this.state.AllAboutToken.accessToken}
      await axios.post(port +'/api/refreshtoken',data).then(response =>{
            this.commit('setAllToken',response.data.data)})
          .catch(function (error) {
            console.log("sdfosdjhfksdhsdkj")
            swal({
              text: error,
              icon: "error",
              });
          });  
      },
    
      async SendEmail(){
        await axios.post(port +'/api/send/'+this.state.user.sub).then(response =>{
        console.log(response)
      })
    },


    async SendForm(state,data){   
      await axios.post(port +'/api/forgotpassword',data).then(response =>{
          console.log(response)
         
          swal({
            text: "На " + data.email +" было отправлено письмо.",
            icon: "success",
          });
          router.push('/')
        }).catch(
          function (error) {
            swal({
              text: "аккаунта с таким email-ом нет, или данная почта раньше не была подтверждена",
              icon: "error",
              });
          console.log(error)});
        //this.Connection()
    },
  

    async Login(state,data){
          await axios.post(port +'/api/login',data).then(response =>{
            console.log(response)    
            this.commit('setAllToken',response.data.data)
            console.log("sdfosdjhfksdhsdkj")
            this.commit("setUser",parseJwt(this.state.AllAboutToken.accessToken))
            this.dispatch("Author",this.state.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'])  
            this.dispatch("GetMyItems") 
            this.dispatch("GetOrders")  
            router.push('/')
          }).catch(function (error) {
              swal({
              title: "Ошибка",
              text: "Неправильные данные",
              icon: "error",
              });
            console.log(error)});
    },

    async Author(state,email){
        await axios.get(port +'/api/user/email/'+email).then(response =>{
          this.commit('setUserName',response.data.name)
          this.commit('setUserIsEmail',response.data.emailConfirmed)
        console.log(response.data)
        console.log(this.state.isEmail)
      })
    },

    Exit({commit}){
      commit('setUser',null)
      commit('setAllToken',null)
      commit('setUserName',null)
      commit('setMyItems',[])
      commit('setOrders',[])
      commit('setUserIsEmail',false)
    }

  },



  plugins: [vuexLocalStorage.plugin]
});

