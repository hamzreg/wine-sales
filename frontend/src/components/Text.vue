<template>
    <div class="text" :style="{ fontSize, color } ">
      <slot></slot>
    </div>
</template>


<script lang="ts">
import { defineComponent } from "vue";
export default defineComponent({
  name: "Text",
  components: {},
  props: {
    fontSize: String,
    color: String,
  },
});
</script>
  

<style scoped>
.text {
  font: var(--font-name);
}
</style>