.class public Lcom/igg/sdk/IGGNotificationCenter;
.super Ljava/lang/Object;
.source "IGGNotificationCenter.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/IGGNotificationCenter$Observer;
    }
.end annotation


# static fields
.field private static instance:Lcom/igg/sdk/IGGNotificationCenter;


# instance fields
.field private observers:Ljava/util/HashMap;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/ArrayList",
            "<",
            "Lcom/igg/sdk/IGGNotificationCenter$Observer;",
            ">;>;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 43
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 44
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/IGGNotificationCenter;->observers:Ljava/util/HashMap;

    .line 45
    return-void
.end method

.method public static sharedInstance()Lcom/igg/sdk/IGGNotificationCenter;
    .locals 1

    .prologue
    .line 34
    sget-object v0, Lcom/igg/sdk/IGGNotificationCenter;->instance:Lcom/igg/sdk/IGGNotificationCenter;

    if-nez v0, :cond_0

    .line 35
    new-instance v0, Lcom/igg/sdk/IGGNotificationCenter;

    invoke-direct {v0}, Lcom/igg/sdk/IGGNotificationCenter;-><init>()V

    sput-object v0, Lcom/igg/sdk/IGGNotificationCenter;->instance:Lcom/igg/sdk/IGGNotificationCenter;

    .line 38
    :cond_0
    sget-object v0, Lcom/igg/sdk/IGGNotificationCenter;->instance:Lcom/igg/sdk/IGGNotificationCenter;

    return-object v0
.end method


# virtual methods
.method public addObserver(Ljava/lang/String;Lcom/igg/sdk/IGGNotificationCenter$Observer;)V
    .locals 2
    .param p1, "notificationName"    # Ljava/lang/String;
    .param p2, "observer"    # Lcom/igg/sdk/IGGNotificationCenter$Observer;

    .prologue
    .line 54
    iget-object v0, p0, Lcom/igg/sdk/IGGNotificationCenter;->observers:Ljava/util/HashMap;

    invoke-virtual {v0, p1}, Ljava/util/HashMap;->containsKey(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 55
    iget-object v0, p0, Lcom/igg/sdk/IGGNotificationCenter;->observers:Ljava/util/HashMap;

    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {v0, p1, v1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 58
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/IGGNotificationCenter;->observers:Ljava/util/HashMap;

    invoke-virtual {v0, p1}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/ArrayList;

    invoke-virtual {v0, p2}, Ljava/util/ArrayList;->contains(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 59
    iget-object v0, p0, Lcom/igg/sdk/IGGNotificationCenter;->observers:Ljava/util/HashMap;

    invoke-virtual {v0, p1}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/ArrayList;

    invoke-virtual {v0, p2}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 61
    :cond_1
    return-void
.end method

.method public clearObservers(Ljava/lang/String;)V
    .locals 1
    .param p1, "notificationName"    # Ljava/lang/String;

    .prologue
    .line 85
    iget-object v0, p0, Lcom/igg/sdk/IGGNotificationCenter;->observers:Ljava/util/HashMap;

    invoke-virtual {v0, p1}, Ljava/util/HashMap;->containsKey(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 86
    iget-object v0, p0, Lcom/igg/sdk/IGGNotificationCenter;->observers:Ljava/util/HashMap;

    invoke-virtual {v0, p1}, Ljava/util/HashMap;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    .line 88
    :cond_0
    return-void
.end method

.method public postNotification(Lcom/igg/sdk/IGGNotification;)V
    .locals 3
    .param p1, "notification"    # Lcom/igg/sdk/IGGNotification;

    .prologue
    .line 96
    iget-object v1, p0, Lcom/igg/sdk/IGGNotificationCenter;->observers:Ljava/util/HashMap;

    invoke-virtual {p1}, Lcom/igg/sdk/IGGNotification;->getName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/util/HashMap;->containsKey(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 97
    iget-object v1, p0, Lcom/igg/sdk/IGGNotificationCenter;->observers:Ljava/util/HashMap;

    invoke-virtual {p1}, Lcom/igg/sdk/IGGNotification;->getName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/IGGNotificationCenter$Observer;

    .line 98
    .local v0, "observer":Lcom/igg/sdk/IGGNotificationCenter$Observer;
    invoke-interface {v0, p1}, Lcom/igg/sdk/IGGNotificationCenter$Observer;->onNotification(Lcom/igg/sdk/IGGNotification;)V

    goto :goto_0

    .line 101
    .end local v0    # "observer":Lcom/igg/sdk/IGGNotificationCenter$Observer;
    :cond_0
    return-void
.end method

.method public removeObserver(Ljava/lang/String;Lcom/igg/sdk/IGGNotificationCenter$Observer;)V
    .locals 1
    .param p1, "notificationName"    # Ljava/lang/String;
    .param p2, "observer"    # Lcom/igg/sdk/IGGNotificationCenter$Observer;

    .prologue
    .line 70
    iget-object v0, p0, Lcom/igg/sdk/IGGNotificationCenter;->observers:Ljava/util/HashMap;

    invoke-virtual {v0, p1}, Ljava/util/HashMap;->containsKey(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 77
    :cond_0
    :goto_0
    return-void

    .line 74
    :cond_1
    iget-object v0, p0, Lcom/igg/sdk/IGGNotificationCenter;->observers:Ljava/util/HashMap;

    invoke-virtual {v0, p1}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/ArrayList;

    invoke-virtual {v0, p2}, Ljava/util/ArrayList;->contains(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 75
    iget-object v0, p0, Lcom/igg/sdk/IGGNotificationCenter;->observers:Ljava/util/HashMap;

    invoke-virtual {v0, p1}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/ArrayList;

    invoke-virtual {v0, p2}, Ljava/util/ArrayList;->remove(Ljava/lang/Object;)Z

    goto :goto_0
.end method
