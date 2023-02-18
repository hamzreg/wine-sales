<template>
  <div class="sale-item">
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ wine.kind }}
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ wine.color }}
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ wine.sugar }}
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ wine.volume }}
		</Text>
  </div>
</template>
  
  
<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'
    
export default defineComponent({
  name: "WineItem",
  components: {
    Text
  },
  props: {
    wine: {
      type: Object,
      required: true
    }
  }
})
</script>