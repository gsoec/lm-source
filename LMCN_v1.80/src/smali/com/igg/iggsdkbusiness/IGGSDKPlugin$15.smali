.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$15;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->OpenGooglePlayStoreUrl(Ljava/lang/String;Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

.field final synthetic val$my_package_name:Ljava/lang/String;

.field final synthetic val$pString:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    .prologue
    .line 976
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$15;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$15;->val$pString:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$15;->val$my_package_name:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 7

    .prologue
    .line 984
    new-instance v1, Landroid/content/Intent;

    const-string v3, "android.intent.action.VIEW"

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$15;->val$pString:Ljava/lang/String;

    .line 985
    invoke-static {v4}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v4

    invoke-direct {v1, v3, v4}, Landroid/content/Intent;-><init>(Ljava/lang/String;Landroid/net/Uri;)V

    .line 987
    .local v1, "intent":Landroid/content/Intent;
    :try_start_0
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$15;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-virtual {v3}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v3

    new-instance v4, Landroid/content/Intent;

    const-string v5, "android.intent.action.VIEW"

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$15;->val$pString:Ljava/lang/String;

    .line 988
    invoke-static {v6}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v6

    invoke-direct {v4, v5, v6}, Landroid/content/Intent;-><init>(Ljava/lang/String;Landroid/net/Uri;)V

    .line 987
    invoke-virtual {v3, v4}, Landroid/app/Activity;->startActivity(Landroid/content/Intent;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 997
    :goto_0
    return-void

    .line 989
    :catch_0
    move-exception v0

    .line 990
    .local v0, "e":Ljava/lang/Exception;
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "https://play.google.com/store/apps/details?id="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$15;->val$my_package_name:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    .line 991
    invoke-static {v3}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v2

    .line 993
    .local v2, "url":Landroid/net/Uri;
    const/high16 v3, 0x10080000

    invoke-virtual {v1, v3}, Landroid/content/Intent;->addFlags(I)Landroid/content/Intent;

    .line 995
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$15;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-virtual {v3}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v3

    invoke-virtual {v3, v1}, Landroid/app/Activity;->startActivity(Landroid/content/Intent;)V

    goto :goto_0
.end method
