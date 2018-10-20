.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$7;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->RateUs()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    .prologue
    .line 382
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$7;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 6

    .prologue
    .line 385
    const-string v3, "market://details?id=com.igg.android.lordsonline_tw"

    invoke-static {v3}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v2

    .line 386
    .local v2, "uri":Landroid/net/Uri;
    new-instance v1, Landroid/content/Intent;

    const-string v3, "android.intent.action.VIEW"

    invoke-direct {v1, v3, v2}, Landroid/content/Intent;-><init>(Ljava/lang/String;Landroid/net/Uri;)V

    .line 388
    .local v1, "myAppLinkToMarket":Landroid/content/Intent;
    :try_start_0
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$7;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-virtual {v3}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v3

    invoke-virtual {v3, v1}, Landroid/app/Activity;->startActivity(Landroid/content/Intent;)V

    .line 389
    const-string v3, "RateGooglePlayApplication\uff01"

    invoke-static {v3}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->DebugLog(Ljava/lang/String;)V

    .line 390
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$7;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$7;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->RateUsSuccessfulCallBack:Ljava/lang/String;

    const-string v5, "true"

    invoke-virtual {v3, v4, v5}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Landroid/content/ActivityNotFoundException; {:try_start_0 .. :try_end_0} :catch_0

    .line 397
    :goto_0
    return-void

    .line 391
    :catch_0
    move-exception v0

    .line 392
    .local v0, "e":Landroid/content/ActivityNotFoundException;
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$7;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-virtual {v3}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v3

    invoke-virtual {v3}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v3

    const-string v4, " unable to find market app"

    const/4 v5, 0x1

    invoke-static {v3, v4, v5}, Landroid/widget/Toast;->makeText(Landroid/content/Context;Ljava/lang/CharSequence;I)Landroid/widget/Toast;

    move-result-object v3

    .line 394
    invoke-virtual {v3}, Landroid/widget/Toast;->show()V

    .line 395
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$7;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$7;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->RateUsFailedCallBack:Ljava/lang/String;

    const-string v5, "false"

    invoke-virtual {v3, v4, v5}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
