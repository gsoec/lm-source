.class public Lcom/igg/sdk/IGGSDK$Notification;
.super Ljava/lang/Object;
.source "IGGSDK.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/IGGSDK;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = "Notification"
.end annotation


# static fields
.field public static final FIRST_LOGIN:Ljava/lang/String; = "FIRST_LOGIN"

.field public static final FIRST_START_UP:Ljava/lang/String; = "FIRST_START_UP"


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/IGGSDK;


# direct methods
.method public constructor <init>(Lcom/igg/sdk/IGGSDK;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/IGGSDK;

    .prologue
    .line 37
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK$Notification;->this$0:Lcom/igg/sdk/IGGSDK;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method
