import Vue from 'vue'

// signalR 客户端调用
// 服务器端发送消息

// 给某一个个人
export function messagesendtosomeone (parameter) {
  Vue.socket.invoke('ClientsSendMessage', { userId: parameter.userId, title: parameter.title, message: parameter.message, messagetype: parameter.messagetype })
  .then(response => {
  })
}

// 给所有人
export function messagesendtoAll (parameter) {
  Vue.socket.invoke('ClientsSendMessagetoAll', { title: parameter.title, message: parameter.message, messagetype: parameter.messagetype })
  .then(response => {
  })
}

// 给某些人
export function messagesendtouserList (parameter) {
  Vue.socket.invoke('ClientsSendMessagetoUsers', { userId: parameter.userList, title: parameter.title, message: parameter.message, messagetype: parameter.messagetype })
  .then(response => {
  })
}
// 除了发送人 发送给剩下的人
export function messagesendtoexsomeone (parameter) {
  Vue.socket.invoke('ClientsSendMessagetoOther', { userIds: parameter.userIds, title: parameter.title, message: parameter.message, messagetype: parameter.messagetype })
  .then(response => {
  })
}
