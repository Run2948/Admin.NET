<template>
  <div class="logo">
    <router-link :to="{ name: 'Console' }">
      <LogoSvg alt="logo" />
      <h1 v-if="showTitle">{{ this.text }}</h1>
    </router-link>
  </div>
</template>

<script>
import LogoSvg from '@/assets/logo.svg?inline'
import { mixin, mixinDevice } from '@/utils/mixin'

export default {
  name: 'Logo',
  components: {
    LogoSvg
  },
  mixins: [mixin, mixinDevice],
  data() {
    return {
      text: ''
    }
  },
  props: {
    title: {
      type: String,
      default: 'Admin.NET',
      required: false
    },
    showTitle: {
      type: Boolean,
      default: true,
      required: false
    }
  },
  created() {
    if (this.layoutMode === 'topmenu') {
      if (this.title.length > 8) {
        this.text = this.title.substring(0, 8) + '...'
      } else {
        this.text = this.title
      }
    } else {
      if (this.title.length > 10) {
        this.text = this.title.substring(0, 8) + '...'
      } else {
        this.text = this.title
      }
    }
  }
}
</script>
