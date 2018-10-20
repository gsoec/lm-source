.class public Lcom/igg/iggsdkbusiness/GCMIntentService;
.super Lcom/igg/sdk/push/IGGGCMIntentService;
.source "GCMIntentService.java"


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 22
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getGCMSenderId()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/igg/sdk/push/IGGGCMIntentService;-><init>(Ljava/lang/String;)V

    .line 23
    return-void
.end method


# virtual methods
.method protected notificationIcon(Landroid/content/Context;)I
    .locals 5
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 48
    invoke-virtual {p1}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v1

    const-string v2, "app_icon"

    const-string v3, "drawable"

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v1, v2, v3, v4}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v0

    .line 49
    .local v0, "pId":I
    if-nez v0, :cond_0

    .line 51
    invoke-virtual {p1}, Landroid/content/Context;->getApplicationInfo()Landroid/content/pm/ApplicationInfo;

    move-result-object v1

    iget v0, v1, Landroid/content/pm/ApplicationInfo;->icon:I

    .line 53
    :cond_0
    const-string v1, "Notification"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "notificationIcon ID = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 54
    return v0
.end method

.method protected notificationTitle(Landroid/content/Context;)Ljava/lang/String;
    .locals 1
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 34
    const-string v0, "\u738b\u56fd\u7eaa\u5143"

    return-object v0
.end method
