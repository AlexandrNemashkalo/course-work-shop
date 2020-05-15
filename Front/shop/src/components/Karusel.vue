<template>
 <carousel-3d>
<slide :index="0" :height="20">
    <img src="..\assets\img\1200px-Логотип_МИЭМ.svg.png"  alt="">
</slide>
<slide :index="1">
    Slide2
</slide>
<slide :index="2">
    Slide3
</slide>
<slide :index="3">
    Slide3
</slide>
<slide :index="4">
    Slide3
</slide>
</carousel-3d>

</template>
<script>
import {Carousel3d, Slide} from 'vue-carousel-3d';

/*<carousel-3d>
    <slide v-for="(slide, i) in slides" :index="i" :key="i">
        <template slot-scope="{ index, isCurrent, leftIndex, rightIndex }">
            <img :data-index="index" :class="{ current: isCurrent, onLeft: (leftIndex >= 0), onRight: (rightIndex >= 0) }" :src="slide.src">
        </template>
    </slide>
</carousel-3d>*/
export default {
   
      data() {
          return {
            slides: 3
          }
  },
  components: {
    Carousel3d,
    Slide
  }
}
</script>