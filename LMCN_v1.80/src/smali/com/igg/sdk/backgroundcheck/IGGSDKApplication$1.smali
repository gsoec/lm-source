.class Lcom/igg/sdk/backgroundcheck/IGGSDKApplication$1;
.super Ljava/lang/Object;
.source "IGGSDKApplication.java"

# interfaces
.implements Landroid/app/Application$ActivityLifecycleCallbacks;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->onCreate()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;


# direct methods
.method constructor <init>(Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;

    .prologue
    .line 17
    iput-object p1, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication$1;->this$0:Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onActivityCreated(Landroid/app/Activity;Landroid/os/Bundle;)V
    .locals 0
    .param p1, "activity"    # Landroid/app/Activity;
    .param p2, "savedInstanceState"    # Landroid/os/Bundle;

    .prologue
    .line 20
    return-void
.end method

.method public onActivityDestroyed(Landroid/app/Activity;)V
    .locals 0
    .param p1, "activity"    # Landroid/app/Activity;

    .prologue
    .line 50
    return-void
.end method

.method public onActivityPaused(Landroid/app/Activity;)V
    .locals 0
    .param p1, "activity"    # Landroid/app/Activity;

    .prologue
    .line 34
    return-void
.end method

.method public onActivityResumed(Landroid/app/Activity;)V
    .locals 0
    .param p1, "activity"    # Landroid/app/Activity;

    .prologue
    .line 30
    return-void
.end method

.method public onActivitySaveInstanceState(Landroid/app/Activity;Landroid/os/Bundle;)V
    .locals 0
    .param p1, "activity"    # Landroid/app/Activity;
    .param p2, "outState"    # Landroid/os/Bundle;

    .prologue
    .line 45
    return-void
.end method

.method public onActivityStarted(Landroid/app/Activity;)V
    .locals 2
    .param p1, "activity"    # Landroid/app/Activity;

    .prologue
    .line 24
    iget-object v0, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication$1;->this$0:Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;

    invoke-static {v0}, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->access$008(Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;)I

    .line 25
    invoke-static {}, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->sharedInstance()Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication$1;->this$0:Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;

    invoke-static {v1}, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->access$000(Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;)I

    move-result v1

    invoke-virtual {v0, v1}, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->setCount(I)V

    .line 26
    return-void
.end method

.method public onActivityStopped(Landroid/app/Activity;)V
    .locals 2
    .param p1, "activity"    # Landroid/app/Activity;

    .prologue
    .line 38
    iget-object v0, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication$1;->this$0:Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;

    invoke-static {v0}, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->access$010(Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;)I

    .line 39
    invoke-static {}, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->sharedInstance()Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication$1;->this$0:Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;

    invoke-static {v1}, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->access$000(Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;)I

    move-result v1

    invoke-virtual {v0, v1}, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->setCount(I)V

    .line 40
    return-void
.end method
