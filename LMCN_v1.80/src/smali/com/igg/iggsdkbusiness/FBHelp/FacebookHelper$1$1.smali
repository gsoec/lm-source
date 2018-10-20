.class Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;
.super Ljava/lang/Object;
.source "FacebookHelper.java"

# interfaces
.implements Lcom/facebook/GraphRequest$GraphJSONObjectCallback;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->onSuccess(Lcom/facebook/login/LoginResult;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

.field final synthetic val$token:Ljava/lang/String;

.field final synthetic val$userId:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    .prologue
    .line 251
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->val$userId:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->val$token:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCompleted(Lorg/json/JSONObject;Lcom/facebook/GraphResponse;)V
    .locals 6
    .param p1, "object"    # Lorg/json/JSONObject;
    .param p2, "response"    # Lcom/facebook/GraphResponse;

    .prologue
    .line 255
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    const-string v1, "newMeRequest onCompleted"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 256
    if-eqz p1, :cond_0

    .line 257
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    const-string v1, "email"

    invoke-virtual {p1, v1}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->mail:Ljava/lang/String;

    .line 258
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    const-string v1, "name"

    invoke-virtual {p1, v1}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->name:Ljava/lang/String;

    .line 259
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "RegisterCallback mail = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->mail:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 260
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "RegisterCallback name = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->name:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 262
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;->Switch:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_FBCallbackType:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    if-ne v0, v1, :cond_2

    .line 263
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->mail:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->name:Ljava/lang/String;

    iget-object v3, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->val$userId:Ljava/lang/String;

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->val$token:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    invoke-static/range {v0 .. v5}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->access$000(Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;)V

    .line 267
    :cond_1
    :goto_0
    return-void

    .line 264
    :cond_2
    sget-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;->Bind:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_FBCallbackType:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    if-ne v0, v1, :cond_1

    .line 265
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->mail:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->name:Ljava/lang/String;

    const-string v3, "Facebook"

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->val$token:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;->this$0:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    invoke-static/range {v0 .. v5}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->access$100(Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;)V

    goto :goto_0
.end method
