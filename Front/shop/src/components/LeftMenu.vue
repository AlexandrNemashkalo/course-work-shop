<template>
  <div id="app">
    <button @click="toggle">toggle</button>
    <Drawer @close="toggle" align="left" :closeable="true">
      <div v-if="open">content here</div>
    </Drawer>
  </div>
</template>

<script>
import Drawer from "vue-simple-drawer"
export default {
  name: "app",
  data() {
    return {
      open: true
    }
  },
  components: {
    Drawer
  },
  methods: {
    toggle() {
      this.open = !this.open
    }
  }
}
</script>