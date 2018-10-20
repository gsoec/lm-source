.class Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask$1;
.super Ljava/lang/Object;
.source "IGGAppConfigService.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->run()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;

.field final synthetic val$appConfig:Lcom/igg/sdk/bean/IGGAppConfig;

.field final synthetic val$tmpListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;Lcom/igg/sdk/bean/IGGAppConfig;Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;

    .prologue
    .line 93
    iput-object p1, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask$1;->this$1:Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask$1;->val$appConfig:Lcom/igg/sdk/bean/IGGAppConfig;

    iput-object p3, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask$1;->val$tmpListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 4

    .prologue
    const/4 v3, 0x0

    .line 96
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask$1;->val$appConfig:Lcom/igg/sdk/bean/IGGAppConfig;

    if-eqz v0, :cond_0

    .line 97
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask$1;->val$tmpListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    invoke-virtual {v0}, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->getAppConfigListener()Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    move-result-object v0

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask$1;->val$appConfig:Lcom/igg/sdk/bean/IGGAppConfig;

    invoke-interface {v0, v1, v2}, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;->onAppConfigLoadFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/bean/IGGAppConfig;)V

    .line 101
    :goto_0
    return-void

    .line 99
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask$1;->val$tmpListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    invoke-virtual {v0}, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->getAppConfigListener()Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    move-result-object v0

    new-instance v1, Lcom/igg/sdk/error/IGGError;

    sget-object v2, Lcom/igg/sdk/error/IGGError$Type;->REMOTE:Lcom/igg/sdk/error/IGGError$Type;

    invoke-direct {v1, v2, v3}, Lcom/igg/sdk/error/IGGError;-><init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;)V

    invoke-interface {v0, v1, v3}, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;->onAppConfigLoadFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/bean/IGGAppConfig;)V

    goto :goto_0
.end method
