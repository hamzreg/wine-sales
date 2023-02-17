<template>
  <div style="height: var(--navbar-height)">
    <NavBarHome />
  </div>
  <div class="main" style="height: calc(100% - var(--navbar-height))">
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import NavBarHome from "@/components/navBarHome/NavBarHome.vue"

export default defineComponent({
  name: "NavBarView",
  components: {
    NavBarHome,
  }
})
</script>

<style scoped>
.main {
  display: flex;
  flex-direction: column;
  margin: 0;
  width: 100%;
  height: 100%;
  justify-content: center;
  align-items: center;
  overflow: scroll;
}
</style>