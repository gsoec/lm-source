.class Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;
.super Landroid/os/AsyncTask;
.source "AlipayHelper.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->alipay(Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Landroid/os/AsyncTask",
        "<",
        "Ljava/lang/Object;",
        "Ljava/lang/Integer;",
        "Ljava/lang/Object;",
        ">;"
    }
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

.field final synthetic val$activity:Landroid/app/Activity;

.field final synthetic val$listener:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

.field final synthetic val$payInfo:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    .prologue
    .line 100
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;->this$0:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;->val$activity:Landroid/app/Activity;

    iput-object p3, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;->val$payInfo:Ljava/lang/String;

    iput-object p4, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

    invoke-direct {p0}, Landroid/os/AsyncTask;-><init>()V

    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 5
    .param p1, "params"    # [Ljava/lang/Object;

    .prologue
    .line 105
    new-instance v0, Lcom/alipay/sdk/app/PayTask;

    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;->val$activity:Landroid/app/Activity;

    invoke-direct {v0, v3}, Lcom/alipay/sdk/app/PayTask;-><init>(Landroid/app/Activity;)V

    .line 107
    .local v0, "alipay":Lcom/alipay/sdk/app/PayTask;
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;->val$payInfo:Ljava/lang/String;

    const/4 v4, 0x1

    invoke-virtual {v0, v3, v4}, Lcom/alipay/sdk/app/PayTask;->pay(Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v2

    .line 108
    .local v2, "result":Ljava/lang/String;
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 109
    .local v1, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/Object;>;"
    const-string v3, "result"

    invoke-virtual {v1, v3, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 110
    return-object v1
.end method

.method protected onPostExecute(Ljava/lang/Object;)V
    .locals 6
    .param p1, "map"    # Ljava/lang/Object;

    .prologue
    const/4 v5, 0x0

    .line 117
    move-object v0, p1

    check-cast v0, Ljava/util/HashMap;

    .line 118
    .local v0, "hashMap":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/Object;>;"
    const-string v4, "result"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 119
    .local v2, "result":Ljava/lang/String;
    new-instance v1, Lcom/igg/iggsdkbusiness/Alipay/PayResult;

    invoke-direct {v1, v2}, Lcom/igg/iggsdkbusiness/Alipay/PayResult;-><init>(Ljava/lang/String;)V

    .line 120
    .local v1, "payResult":Lcom/igg/iggsdkbusiness/Alipay/PayResult;
    invoke-virtual {v1}, Lcom/igg/iggsdkbusiness/Alipay/PayResult;->getResultStatus()Ljava/lang/String;

    move-result-object v3

    .line 122
    .local v3, "resultStatus":Ljava/lang/String;
    const-string v4, "9000"

    invoke-static {v3, v4}, Landroid/text/TextUtils;->equals(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_0

    .line 123
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;->this$0:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    invoke-static {v4, v5}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->access$002(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;Z)Z

    .line 124
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

    invoke-interface {v4, v1}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;->onSuccess(Lcom/igg/iggsdkbusiness/Alipay/PayResult;)V

    .line 138
    :goto_0
    return-void

    .line 128
    :cond_0
    const-string v4, "8000"

    invoke-static {v3, v4}, Landroid/text/TextUtils;->equals(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_1

    .line 129
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;->this$0:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    invoke-static {v4, v5}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->access$002(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;Z)Z

    .line 130
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

    invoke-interface {v4}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;->onWaitResult()V

    goto :goto_0

    .line 134
    :cond_1
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;->this$0:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    invoke-static {v4, v5}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->access$002(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;Z)Z

    .line 135
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

    invoke-interface {v4}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;->onError()V

    goto :goto_0
.end method
