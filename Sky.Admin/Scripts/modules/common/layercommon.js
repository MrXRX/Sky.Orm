var LayerCommonJs = {
    Init: function () {

    },
    LayerOpen: function (content, icon) {
        /*****************
        *icon :
        *0����̾��
        *1���ɹ�
        *2��ʧ��
        *3���ʺ�
        *4����
        *5��������
        *6������
        ****************/
        parent.layer.open({
            title: "��ܰ��ʾ",
            content: content || "�����ɹ�",
            icon: icon || 1,
            scrollbar: true,
            time: time,
            btn: "֪����"
        });
    }
}



$(function () {
    LayerCommonJs.Init();
})
