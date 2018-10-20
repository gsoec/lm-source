.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$16;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->RateGooglePlayApplication(Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

.field final synthetic val$pString:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    .prologue
    .line 1006
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$16;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$16;->val$pString:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 6

    .prologue
    .line 1009
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$16;->val$pString:Ljava/lang/String;

    invoke-static {v3}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v2

    .line 1011
    .local v2, "uri":Landroid/net/Uri;
    new-instance v1, Landroid/content/Intent;

    const-string v3, "android.intent.action.VIEW"

    invoke-direct {v1, v3, v2}, Landroid/content/Intent;-><init>(Ljava/lang/String;Landroid/net/Uri;)V

    .line 1013
    .local v1, "myAppLinkToMarket":Landroid/content/Intent;
    :try_start_0
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$16;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-virtual {v3}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v3

    invoke-virtual {v3, v1}, Landroid/app/Activity;->startActivity(Landroid/content/Intent;)V

    .line 1014
    const-string v3, "RateGooglePlayApplication\uff01"

    invoke-static {v3}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->DebugLog(Ljava/lang/String;)V

    .line 1015
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$16;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    const-string v4, "RateGooglePlayApplicationSucceeded"

    const-string v5, "true"

    invoke-virtual {v3, v4, v5}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Landroid/content/ActivityNotFoundException; {:try_start_0 .. :try_end_0} :catch_0

    .line 1024
    :goto_0
    return-void

    .line 1017
    :catch_0
    move-exception v0

    .line 1018
    .local v0, "e":Landroid/content/ActivityNotFoundException;
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$16;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-virtual {v3}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v3

    invoke-virtual {v3}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v3

    const-string v4, " unable to find market app"

    const/4 v5, 0x1

    invoke-static {v3, v4, v5}, Landroid/widget/Toast;->makeText(Landroid/content/Context;Ljava/lang/CharSequence;I)Landroid/widget/Toast;

    move-result-object v3

    .line 1020
    invoke-virtual {v3}, Landroid/widget/Toast;->show()V

    .line 1021
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$16;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    const-string v4, "RateGooglePlayApplicationSucceeded"

    const-string v5, "false"

    invoke-virtual {v3, v4, v5}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
