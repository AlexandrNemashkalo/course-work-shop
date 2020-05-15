<template>
<div  style='overflow-x:hidden;margin-left: 0px;'>
  <div  class="mt-0   page-main   "> 

<header  class="m-0 p-0">
  <div  id="header" class="">
    <div class="container-lg pt-1 pb-2 pl-4 ">
      <div class="row">
       <div class="col-8">
    <router-link to="/admin"> <span style="font-size:17px;color:white">Администрирование </span></router-link>
       </div>
         <div class="col-4 text-right ">
           <router-link to="/"><img :src="require('@/assets/img/выйти.png')" style="width:25px"   class=" mr-1 pt-1 "/><span style="font-size:17px;" class="link">Выйти</span> </router-link>
       </div>
      </div>  
    </div>
  </div>    
    </header>



    <div class="container-lg mt-lg-5 mt-4 adminka  "  >
      <div class="row">

        <div class=" col-12">
          <div class="mymenu3 p-3 mb-4">
            <div class="row">
          <div class="col-3 text-left pr-0"> 
            <span><strong>Блюда</strong></span>
          </div>
          <div class="col-5 text-left  pr-0"> 
            
             <b-form-input class="w-100" placeholder="Поиск по названию" v-model="search" style="font-size:15px"  ></b-form-input>
          </div>
          <div class="col-4 pl- text-right">
             <button v-if="!showAdd" type="button" @click="showAdd=true" class="btn btn-success">Добавить</button>
            </div>
          </div>
          </div>
        </div>

        <div class="col-12">

            <div class="mymenu3 p-3 mb-2 d-md-block d-none">
              <div class="row ">
                  <div class="col-md-2 col-5 text-left">
                    <span> <strong>Название  </strong> </span>
                  </div>
                  
                  <div class="col-md-2 col-6 pl-0 ">
                    <span> <strong>Категория </strong> </span>
                  </div>
                   <div class="col-md-2 col-6 pl-0">
                    <span> <strong>Изображение</strong> </span>
                  </div>
                    <div class="col-md-2 col-6  pl-0">
                    <span> <strong>Описание</strong> </span>
                  </div>
                    <div class="col-md-1 col-6 pl-0">
                    <span> <strong>Рейтинг</strong> </span>
                  </div>
                   <div class="col-md-1 col-6 pl-0  ">
                    <span> <strong>Цена </strong>/ <strong> Граммы</strong></span>
                  </div>
                  <div class="col-md-1 col-6 pl-0 ">
                    <span> <strong>Наличие</strong> </span>
                  </div>
                  <div class="col-md-1 col-6 pl-0 ">
                    <span> <strong>Компл.</strong> </span>
                  </div>
              </div>
            </div>




<div v-if="showAdd"   class="mymenu3  m-0 w-100 mt-lg-4 mb-3 p-3 product-item " style="position:relative"  >
         
           <button type="button" @click="showAdd=false" style="position:absolute;bottom:10px;right:5px;z-index:6" class="btn btn-warning">&#10006;</button>
           
    <form action="" class="w-100 pl-4 row"  @submit.prevent="AddItem">
           <div class="col-md-2 col-12 pl-0" >
             <div >
             <span class="d-md-none d-inline-block text-left"> <strong>Название:</strong> </span>
             <b-form-input v-model="addItem.name" style="font-size:15px" required ></b-form-input>
             </div>
           </div>

           <div class="col-md-2 pl-0">
              <span class="d-md-none d-inline-block"> <strong>Категория:</strong> </span>
                <b-form-select style="font-size:15px"  v-model="addItem.categoryId" :options="options" required></b-form-select>
           </div>

           <div  class="col-md-2 pl-0">
              <span class="d-md-none d-inline-block"> <strong>Изображение:</strong> </span>
                  <b-form-file  style="overflow:hidden;font-size:15px"
              v-model="addItem.file"
              
              required
            ></b-form-file>  
           </div>

            <div class="col-md-2 pl-0">
               <span class="d-md-none d-inline-block"> <strong>Состав:</strong> </span>
            <b-form-textarea  style="font-size:15px"
                id="textarea-default"
                v-model="addItem.text"
                required
            ></b-form-textarea>
           </div>

           <div class="col-md-1 pl-0"> 
           </div>
           
           <div class="col-md-1 pl-0">
              <span class="d-md-none d-inline-block"> <strong>Стоимость/Граммы:</strong> </span>
                <b-form-input v-model="addItem.cost" style="font-size:15px" type="number" required ></b-form-input>
                <b-form-input v-model="addItem.grams" style="font-size:15px" type="number" required ></b-form-input>
           </div>

            <div class="col-md-1 pl-0">
               <span class="d-md-none d-inline-block"> <strong>Есть ли в наличии:</strong> </span>       
<b-form-checkbox  v-model="addItem.status" name="check-button" switch size="lg">
    </b-form-checkbox>
           </div>

           <div class="col-md-1 pl-0 pr-4 ">
             <div class="w-75">
               <span class="d-md-none d-inline-block "> <strong>Входит ли в комплекс:</strong> </span>
             <b-form-checkbox v-model="addItem.komplex" name="check-button" switch size="lg">  </b-form-checkbox>
                
              
               </div>
              
           </div>
             <button type="submit" style="position:absolute;bottom:40px;right:5px;z-index:6" class="btn btn-success">&#10010;</button>
           </form>
           </div>
















 <div v-for="item in  this.$store.state.items" :key="item.id" style="position:relative;overflow: visible;">

        <div v-if="search==''?true: item.name.toLowerCase().indexOf(search.toLowerCase())>=0"  class="mymenu2  row m-0 w-100 mt-lg-4 mb-3 p-3 product-item "  >
          
      <div v-if="Edit(item.id)" class="p-0" style="font-size:20px;position:absolute;right:-5px;top:0px; ">
        <b-dropdown size="lg"  class="p-0"   variant="link" toggle-class="text-decoration-none" no-caret>
          <template v-slot:button-content style="color:black;font-size:20px;z-index:5">
            <span style="color:black;font-size:20px;z-index:5"  >⋮</span>
          </template>
          <div style="z-index:6;font-size:12px" >
          <b-dropdown-item  @click="Delete(item.id)" style="z-index:10;font-size:12px" href="#">Удалить</b-dropdown-item>
          <b-dropdown-item  style="z-index:10;font-size:12px" @click="editId= item.id" href="#">Изменить</b-dropdown-item>
          </div>
        </b-dropdown>
      </div>

      <div v-if="!Edit(item.id)" style="font-size:20px;position:absolute;right:5px;top:5px;z-index:100 ">
          <button class="p-0 btn btn-light" @click="SaveEdit(item)" style="font-size:15px;z-index:100">	&#128190;</button>
      </div>



           <div class="col-md-2 pl-0 ">
             <span class="d-md-none d-inline-block text-left"> <strong>Название:</strong> </span>
               <b-form-input v-if="!Edit(item.id)" v-model="item.name" style="font-size:15px" required ></b-form-input>
           
             <router-link :to="'/item/'+item.id"><span v-if="Edit(item.id)"  class="text-right"> {{item.name}}</span></router-link>
           </div>

           <div class="col-md-2 pl-0">
              <span class="d-md-none d-inline-block"> <strong>Категория:</strong> </span>
                <b-form-select style="font-size:15px" v-if="!Edit(item.id)" v-model="item.categoryId" :options="options"></b-form-select>
                <span v-if="Edit(item.id)" class="text-right">{{GetNameCategory(item.categoryId)}}</span>  
           </div>

           <div  class="col-md-2 pl-0">
              <span class="d-md-none d-inline-block"> <strong>Изображение:</strong> </span>
                  <b-form-file v-if="!Edit(item.id)" style="overflow:hidden"
              v-model="file"
              :placeholder="item.img"
            ></b-form-file>
                <span v-if="Edit(item.id)" class="text-right">{{item.img}}</span>
           </div>

            <div class="col-md-2 pl-0">
               <span class="d-md-none d-inline-block"> <strong>Состав:</strong> </span>
            <b-form-textarea v-if="!Edit(item.id)" style="font-size:15px"
                id="textarea-default"
                v-model="item.text"
            ></b-form-textarea>
                 <span v-if="Edit(item.id)" class="text-right"> {{item.text}}</span>
           </div>

           <div class="col-md-1 pl-0">
              <span class="d-md-none d-inline-block"> <strong>Рейтинг:</strong> </span>  
                <span  class="text-right">  {{Math.round(item.stars/item.kStars)}}</span>
              
           </div>
           <div class="col-md-1 pl-0">
              <span class="d-md-none d-inline-block"> <strong>Стоимость/Граммы:</strong> </span>
               <b-form-input v-if="!Edit(item.id)" v-model="item.cost" type="number" style="font-size:15px" required ></b-form-input>
                <span v-if="Edit(item.id)" class="text-right mr-2">    {{item.cost}} руб</span > 
                <b-form-input v-if="!Edit(item.id)" v-model="item.grams" type="number" style="font-size:15px" required ></b-form-input>
                <span v-if="Edit(item.id)" class="text-right">    {{item.grams}} г</span>
            
            
           </div>
            <div class="col-md-1 pl-0">
               <span class="d-md-none d-inline-block"> <strong>Есть ли в наличии:</strong> </span>       
<b-form-checkbox v-if="!Edit(item.id)" v-model="item.status" name="check-button" switch size="lg">
    </b-form-checkbox>
                 <span v-if="Edit(item.id)" class="text-right">  {{item.status}}</span>
           </div>



           <div class="col-md-1 pl-0 pr-4 ">
             <div class="w-75">
               <span class="d-md-none d-inline-block "> <strong>Входит ли в комплекс:</strong> </span>
             <b-form-checkbox v-if="!Edit(item.id)" v-model="item.komplex" name="check-button" switch size="lg">  </b-form-checkbox>
                 <span v-if="Edit(item.id)" class="text-right"> {{item.komplex}} </span>
              
               </div>
              
           </div>
        </div>
        </div>

        </div>
      </div>
    </div>
  </div>  

  </div>  
</template>
<script>

import swal from 'sweetalert'

export default {
  name: "Main",
  components: {
  
  },
  data(){
    return{
      editId:"",
       selected: null,
        options: [],
        file: null,
        status: 'not_accepted',
        addItem:{
          name:null,
          status : false,
          categoryId: null,
          img:null,
          cost: null,
          komplex: false,
          text:null,
          file:null
        },
        showAdd: false,
        search:""
    }
  },
  async mounted(){

        if(this.$store.state.AllAboutToken && this.$store.state.user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']=='admin'){
        console.log("go")
        this.$store.state.categories.map(e => this.options.push({value: e.id, text: e.name}))
        await this.$store.dispatch('GetItems')
        }
        else{
            this.$router.push('/')
        }
    
  },
  methods:{
      GetNameCategory(id){
        return  this.$store.state.categories.find(e => e.id == id).name

      },
      async Delete(id){
        swal({
  title: "Вы действительно хотите удалить товар?",
  text: "После удаления товара удалиться все что с ним связано:коментарии,отзывы, покупки",
  icon: "warning",
  buttons: true,
  dangerMode: true,
})
.then((willDelete) => {
  if (willDelete) {
     this.$store.dispatch("DeleteItem",id)
    swal("Товар был успешно удален", {
      icon: "success",
    });
    
  } else {
    swal("Вы сохранили ему жизнь!");
  }
});  
      },
      Edit(id){
        
        return this.editId == id? false :true
      },
      SaveEdit(item){
        console.log(item)
        console.log(this.file)
        item.img = this.file==null? item.img: this.file.name
        this.$store.dispatch("EditItem",item)
        this.editId = ""
        this.file = null
      },
      async AddItem(){
        console.log(this.addItem)
        this.addItem.img = this.addItem.file.name
        await this.$store.dispatch("AddItem",this.addItem)
        this.showAdd =false
      }
    
}
  
}
</script>
