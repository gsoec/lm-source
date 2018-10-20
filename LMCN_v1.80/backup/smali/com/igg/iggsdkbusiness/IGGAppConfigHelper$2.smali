.class Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$2;
.super Ljava/lang/Object;
.source "IGGAppConfigHelper.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->LoadEventConfig()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    .prologue
    .line 54
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$2;->this$0:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onAppConfigLoadFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/bean/IGGAppConfig;)V
    .locals 3
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "appconfig"    # Lcom/igg/sdk/bean/IGGAppConfig;

    .prologue
    .line 58
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 60
    if-eqz p2, :cond_0

    .line 62
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$2;->this$0:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$2;->this$0:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->EventCarnivalCallBackSuccessful:Ljava/lang/String;

    invoke-virtual {p2}, Lcom/igg/sdk/bean/IGGAppConfig;->getRawString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 67
    :goto_0
    return-void

    .line 66
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$2;->this$0:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$2;->this$0:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->EventCarnivalCallBackFailed:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
